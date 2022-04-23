namespace Mongin.Mechanics.Experience
{
    /// <summary>
    /// Experience gain implementation for Generation 5. The specimen receives more EXP the
    /// lower its level relative to the opponent's is.
    /// </summary>
    public class GenVExperienceGain : IExperienceGain
    {
        public const int MaximumSingleGain = 100000;

        public int GetGainedExperience(ExpContributor contributor, ExpOpponent opponent, ExpStaticParams static_)
        {
            var overallGain = GetFlatGain(contributor, opponent, static_) * GetScaledGain(contributor, opponent) + 1.0;
            var finalMultiplier = contributor.HoldsLuckyEgg ? 1.5 : 1;
            var exp = (int)(overallGain * finalMultiplier);
            return Math.Min(MaximumSingleGain, exp);
        }

        private static double GetExpShareMultiplier(ExpContributor contributor, ExpStaticParams static_)
        {
            if (static_.ExpShareHolders == 0)
            {
                return static_.UnfaintedContributors;
            }
            else if (contributor.HoldsExpShare)
            {
                return 2 * static_.ExpShareHolders;
            }
            return 2 * static_.UnfaintedContributors;
        }

        private static double GetFlatGain(ExpContributor contributor, ExpOpponent opponent, ExpStaticParams static_)
        {
            var trainerMul = static_.IsTrainerBattle ? 1.5 : 1;
            var gain = trainerMul * opponent.ExpYield * opponent.Level.Value;
            var share = 5.0 * GetExpShareMultiplier(contributor, static_);
            return gain / share;
        }

        private static double GetScaledGain(ExpContributor contributor, ExpOpponent opponent)
        {
            var gain = 2 * opponent.Level.Value + 10.0;
            var reduc = opponent.Level.Value + contributor.Level.Value + 10.0;
            return Math.Pow(gain / reduc, 2.5);
        }
    }
}