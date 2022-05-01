namespace Mongin.Mechanics.Utils
{
    /// <summary>
    /// A probability value between zero and one.
    /// </summary>
    public record Probability(double Value)
    {
        public const double Minimum = 0;
        public const double Maximum = 1;

        public double Value { get; } = Value >= Minimum && Value <= Maximum ? Value : throw new ArgumentException($"Probability must be in range {Minimum}-{Maximum}, got {Value}", nameof(Value));
    }
}