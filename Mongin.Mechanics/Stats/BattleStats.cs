namespace Mongin.Mechanics.Stats
{
    /// <summary>
    /// Battle stats after applying temporary boosts onto the effective stats.
    /// </summary>
    public record BattleStats(EffectiveStats Effective, TemporaryBoosts Boosts)
    {
        public int HP { get; } = Effective.HP;
        public int Attack { get; } = ApplyBoost(Effective.Attack, Boosts.Attack);
        public int Defense { get; } = ApplyBoost(Effective.Defense, Boosts.Defense);
        public int SpecialAttack { get; } = ApplyBoost(Effective.SpecialAttack, Boosts.SpecialAttack);
        public int SpecialDefense { get; } = ApplyBoost(Effective.SpecialDefense, Boosts.SpecialDefense);
        public int Speed { get; } = ApplyBoost(Effective.Speed, Boosts.Speed);


        private readonly static double[] Multipliers = new double[] { 1.0, 1.5, 2.0, 2.5, 3.0, 3.5, 4.0 };

        private static int ApplyBoost(int stat, int boost)
        {
            if (boost >= 0)
            {
                return (int)(stat * Multipliers[boost]);
            }
            else
            {
                return (int)(stat / Multipliers[-boost]);
            }
        }
    }
}