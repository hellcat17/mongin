namespace Mongin.Mechanics.Experience
{
    /// <summary>
    /// Interface for a specimen's growth.
    /// </summary>
    public interface IGrowth
    {
        /// <summary>
        /// Get the total EXP required to reach the target level.
        /// </summary>
        /// <param name="rate">Growth rate of the species</param>
        /// <param name="target">Total EXP at that level</param>
        /// <returns>Total experience points required to reach the target level</returns>
        int GetTotalExperience(GrowthRate rate, Level target);

        /// <summary>
        /// Get the EXP required to reach the maximum level. EXP cannot exceed this value. Typically returns
        /// <see cref="GetTotalExperience(GrowthRate, Level)"/> with a level of <see cref="Level.Maximum"/>.
        /// </summary>
        /// <param name="rate">Growth rate of the species</param>
        /// <returns>Total experience points required to reach the maximum level</returns>
        int GetMaximumExperience(GrowthRate rate);

        /// <summary>
        /// Get the missing EXP required to reach the target level. If the specimen already
        /// reached the target level, this must return zero.
        /// </summary>
        /// <param name="rate">Growth rate of the species</param>
        /// <param name="currentExp">Current EXP of the specimen</param>
        /// <param name="target">Desired level to reach</param>
        /// <returns>Experience points needed to reach the target level or zero</returns>
        int GetMissingExperience(GrowthRate rate, int currentExp, Level target);

        /// <summary>
        /// Get the percentage of EXP progress within the current level.
        /// </summary>
        /// <param name="rate">Growth rate of the species</param>
        /// <param name="currentExp">Current EXP of the specimen</param>
        /// <param name="current">Current level of the specimen</param>
        /// <returns>A percentage value between zero and one.</returns>
        double GetExperienceProgress(GrowthRate rate, int currentExp, Level current);
    }
}
