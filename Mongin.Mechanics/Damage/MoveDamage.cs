using Mongin.Mechanics.Utils;

namespace Mongin.Mechanics.Damage
{
    public record MoveDamageConditions
    {
        public bool SameTypeAttackBonus { get; init; }
        public bool IsBurned { get; init; }
        public bool IsPhysicalMove { get; init; }
    }

    public record DamageRange(int Range)
    {
        public const int Minimum = 0;
        public const int Maximum = 15;

        public int Value { get; }
            = Range >= Minimum && Range <= Maximum
                ? Range
                : throw new ArgumentException($"Damage range must be between {Minimum} and {Maximum}, but got {Range}", nameof(Range));
    }

    public static class MoveDamage
    {
        /// <summary>
        /// Get the base damage for a move.
        /// </summary>
        /// <param name="power">Move power</param>
        /// <param name="level">Attacker level</param>
        /// <param name="attackStat">Attacker battle attack/special attack stat</param>
        /// <param name="defenseStat">Defender battle defense/special defense stat</param>
        /// <returns>Base damage dealt</returns>
        public static int GetBaseDamage(int power, Level level, int attackStat, int defenseStat)
        {
            var levelMul = Math.Floor((2.0 * level.Value) / 5.0 + 2.0);
            var damage = Math.Floor(levelMul * power * attackStat / defenseStat);
            return (int)(damage / 50.0 + 2.0);
        }

        /// <summary>
        /// Get the final damage inflicted on a defender. Returns zero if no effect.
        /// </summary>
        /// <param name="baseDamage">Base damage</param>
        /// <param name="range">Random value between 0 and 15</param>
        /// <param name="conditions">Various conditions affecting damage</param>
        /// <param name="primaryEffectiveness">Primary type effectiveness</param>
        /// <param name="secondaryEffectiveness">Secondary type effectiveness</param>
        /// <param name="otherMultipliers">Multipliers from items or abilities</param>
        /// <returns>Final damage inflicted, in absolute health points</returns>
        public static int GetFinalDamage(
            int baseDamage,
            DamageRange range,
            MoveDamageConditions conditions,
            TypeEffectiveness primaryEffectiveness,
            TypeEffectiveness? secondaryEffectiveness,
            double otherMultipliers)
        {
            if (primaryEffectiveness == TypeEffectiveness.NoEffect ||
                (secondaryEffectiveness ?? TypeEffectiveness.Normal) == TypeEffectiveness.NoEffect)
            {
                return 0;
            }

            var effectiveness = TypingDamage.GetMultiplier(primaryEffectiveness, secondaryEffectiveness);
            var stabMul = conditions.SameTypeAttackBonus ? 1.5 : 1;
            var burnMul = conditions.IsBurned && conditions.IsPhysicalMove ? 0.5 : 1;
            var rangeMul = (85 + range.Value) / 100.0;

            var withRange = Math.Floor(baseDamage * rangeMul);
            var withStab = PokeMath.Round(withRange * stabMul);
            var withEff = Math.Floor(withStab * effectiveness);
            var final = PokeMath.Round(withEff * burnMul * otherMultipliers);

            return Math.Max(MinimumDamage, (int)final);
        }

        private const int MinimumDamage = 1;
    }
}