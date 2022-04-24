using Mongin.Mechanics.Utils;

namespace Mongin.Mechanics.Damage
{
    public static class TypingDamage
    {
        public static double GetMultiplier(Typing move, Typing defenderPrimary, Optional<Typing> defenderSecondary)
            => GetMultiplier(
                TypeTable.Value[move][defenderPrimary],
                defenderSecondary.Map<TypeEffectiveness>(t => TypeTable.Value[move][t]));

        public static double GetMultiplier(TypeEffectiveness primary, Optional<TypeEffectiveness> secondary)
            => secondary.HasValue && IsCancellingOut(primary, secondary.GetValue())
                ? 1.0
                : secondary.HasValue
                    ? MapMultiplier(primary) * MapMultiplier(secondary.GetValue())
                    : MapMultiplier(primary);

        private static bool IsCancellingOut(TypeEffectiveness e1, TypeEffectiveness e2)
        {
            return (e1 == TypeEffectiveness.SuperEffective && e2 == TypeEffectiveness.NotVeryEffective)
                || (e1 == TypeEffectiveness.NotVeryEffective && e2 == TypeEffectiveness.SuperEffective);
        }

        private static double MapMultiplier(TypeEffectiveness eff)
            => eff switch
            {
                TypeEffectiveness.SuperEffective => 2,
                TypeEffectiveness.NotVeryEffective => 0.5,
                TypeEffectiveness.NoEffect => 0,
                _ => 1,
            };
    }
}