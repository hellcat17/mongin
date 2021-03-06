namespace Mongin.Mechanics.Species
{
    public record EffortValueYield(int Attack, int Defense, int SpecialAttack, int SpecialDefense, int Speed)
    {
        public const int Minimum = 0;
        public const int Maximum = 3;

        public int Attack { get; } = CheckRange(Attack, nameof(Attack));
        public int Defense { get; } = CheckRange(Defense, nameof(Defense));
        public int SpecialAttack { get; } = CheckRange(SpecialAttack, nameof(SpecialAttack));
        public int SpecialDefense { get; } = CheckRange(SpecialDefense, nameof(SpecialDefense));
        public int Speed { get; } = CheckRange(Speed, nameof(Speed));

        private static int CheckRange(int stat, string statName)
        {
            return stat >= Minimum && stat <= Maximum ? stat : throw new ArgumentException($"Effort value yield must be in range {Minimum}-{Maximum}, but got {stat}", statName);
        }
    }
}