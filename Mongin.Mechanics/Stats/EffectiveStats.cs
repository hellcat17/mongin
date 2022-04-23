namespace Mongin.Mechanics.Stats
{
    /// <summary>
    /// Effective stats for a specimen, as can be seen on the status page. To
    /// be recalculated upon every level-up.
    /// </summary>
    public record EffectiveStats(BaseStats Base, IndividualValues IV, EffortValues EV, Level Level, Nature Nature)
    {
        public int HP { get; } = GetEffectiveHealthStat(Base.HP, IV.HP, EV.HP, Level);
        public int Attack { get; } = GetEffectiveGenericStat(Base.Attack, IV.Attack, EV.Attack, Level, GetNatureBoost(Nature, StatName.Attack));
        public int Defense { get; } = GetEffectiveGenericStat(Base.Defense, IV.Defense, EV.Defense, Level, GetNatureBoost(Nature, StatName.Defense));
        public int SpecialAttack { get; } = GetEffectiveGenericStat(Base.SpecialAttack, IV.SpecialAttack, EV.SpecialAttack, Level, GetNatureBoost(Nature, StatName.SpecialAttack));
        public int SpecialDefense { get; } = GetEffectiveGenericStat(Base.SpecialDefense, IV.SpecialDefense, EV.SpecialDefense, Level, GetNatureBoost(Nature, StatName.SpecialDefense));
        public int Speed { get; } = GetEffectiveGenericStat(Base.Speed, IV.Speed, EV.Speed, Level, GetNatureBoost(Nature, StatName.Speed));

        private static int GetEffectiveHealthStat(int base_, int iv, int ev, Level lvl)
        {
            return (int)(GetGeneticsAndEffortMultiplier(base_, iv, ev, lvl) + lvl.Value + 10);
        }

        private static int GetEffectiveGenericStat(int base_, int iv, int ev, Level lvl, double natureBoost)
        {
            return (int)((GetGeneticsAndEffortMultiplier(base_, iv, ev, lvl) + 5) * natureBoost);
        }

        private static double GetGeneticsAndEffortMultiplier(int base_, int iv, int ev, Level lvl)
        {
            double genetics = base_ * 2.0 + iv;
            double effort = Math.Floor(ev / 4.0);
            return Math.Floor((genetics + effort) * lvl.Value / 100.0);
        }

        private static double GetNatureBoost(Nature nature, StatName stat) =>
            NatureBoosts.Get(nature, stat) switch
            {
                NatureStatChange.Boosted => 1.1,
                NatureStatChange.Weakened => 0.9,
                _ => 1.0,
            };
    }
}