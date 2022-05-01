namespace Mongin.Mechanics.Species
{
    public record CatchRate(int Value)
    {
        public const int Minimum = 0;
        public const int Maximum = 255;

        public int Value { get; } = Value >= Minimum && Value <= Maximum ? Value : throw new ArgumentException($"Catch rate must be in range {Minimum}-{Maximum}, got {Value}", nameof(Value));
    }
}