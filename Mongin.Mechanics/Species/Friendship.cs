namespace Mongin.Mechanics.Species
{
    public record Friendship(int Value)
    {
        public const int Minimum = 0;
        public const int Maximum = 255;

        public int Value { get; } = Value >= Minimum && Value <= Maximum ? Value : throw new ArgumentException($"Friendship must be in range {Minimum}-{Maximum}, got {Value}", nameof(Value));
    }
}