namespace Mongin.Mechanics.Experience
{
    public record ExpContributor(Level Level, bool HoldsExpShare, bool HoldsLuckyEgg)
    {
        public Level Level { get; } = Level;
        public bool HoldsExpShare { get; } = HoldsExpShare;
        public bool HoldsLuckyEgg { get; } = HoldsLuckyEgg;

    }

    public record ExpOpponent(Level Level, int ExpYield)
    {
        public Level Level { get; } = Level;
        public int ExpYield { get; } = ExpYield;
    }

    public record ExpStaticParams(bool IsTrainerBattle, int UnfaintedContributors, int ExpShareHolders)
    {
        public bool IsTrainerBattle { get; } = IsTrainerBattle;
        public int UnfaintedContributors { get; } = UnfaintedContributors >= 1 && UnfaintedContributors <= 6 ? UnfaintedContributors : throw new ArgumentException($"Unfainted contributors must be in range 1-6, got {UnfaintedContributors}", nameof(UnfaintedContributors));
        public int ExpShareHolders { get; } = ExpShareHolders >= 0 && ExpShareHolders <= 6 ? ExpShareHolders : throw new ArgumentException($"Exp-share holders must be in range 0-6, got {ExpShareHolders}", nameof(ExpShareHolders));
    }

    /// <summary>
    /// Interface for gaining experience in battle.
    /// </summary>
    public interface IExperienceGain
    {
        /// <summary>
        /// Get gained experience points when having defeated an enemy. Every contributor needs their
        /// gained experience points calculated separately.
        /// </summary>
        /// <param name="contributor">Params of the specimen who gains the EXP</param>
        /// <param name="opponent">Params of the opponent who was defeated</param>
        /// <param name="factors">Params for all contributors</param>
        /// <returns></returns>
        int GetGainedExperience(ExpContributor contributor, ExpOpponent opponent, ExpStaticParams static_);
    }
}