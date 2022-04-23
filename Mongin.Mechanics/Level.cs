namespace Mongin.Mechanics
{
    public record Level(int Value)
    {
        public const int Minimum = 0;
        public const int Maximum = 100;

        public int Value { get; } = Value >= Minimum && Value <= Maximum ? Value : throw new ArgumentException($"Level must be in range {Minimum}-{Maximum}, got {Value}", nameof(Value));
    }
}