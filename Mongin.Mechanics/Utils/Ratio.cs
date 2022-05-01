namespace Mongin.Mechanics.Utils
{
    /// <summary>
    /// A ratio of two values picked at random.
    /// </summary>
    /// <typeparam name="T">Type of the possible values</typeparam>
    /// <param name="Dependent">First possible value</param>
    /// <param name="Odds">Odds of the first value being picked</param>
    /// <param name="Other">Second possible value</param>
    public record Ratio<T>(T Dependent, Probability Odds, T Other)
    {
        public T Dependent { get; init; } = Dependent;
        public Probability Odds { get; init; } = Odds;
        public T Other { get; init; } = Other;

        /// <summary>
        /// Pick one or the other value depending on a random number between zero and one.
        /// </summary>
        /// <param name="randomValue">Random number between zero and one</param>
        /// <returns><see cref="Dependent"/> or <see cref="Other"/></returns>
        public T Roll(Probability randomValue)
        {
            return randomValue.Value <= Odds.Value ? Dependent : Other;
        }
    }
}