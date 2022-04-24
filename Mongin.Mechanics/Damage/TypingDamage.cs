using Mongin.Mechanics.Utils;

namespace Mongin.Mechanics.Damage
{
    public static class TypingDamage
    {
        public static double GetMultiplier(Typing move, Typing defenderPrimary, Optional<Typing> defenderSecondary)
        {
            var first = TypeTable.Value[move][defenderPrimary];
            var second = defenderSecondary
                .Map<TypeEffectiveness>(t => TypeTable.Value[move][t])
                .GetValueOr(TypeEffectiveness.Normal);

            return IsCancellingOut(first, second) ? 1.0 : MapMultiplier(first) * MapMultiplier(second);
        }

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