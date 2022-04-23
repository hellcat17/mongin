namespace Mongin.Mechanics.Stats
{
    /// <summary>
    /// Effort values for every specimen.
    /// </summary>
    public record EffortValues(int HP, int Attack, int Defense, int SpecialAttack, int SpecialDefense, int Speed)
    {
        public const int Minimum = 0;
        public const int Maximum = 255;
        public const int AccumulatedMaximum = 510;

        public int HP { get; } = CheckRange(HP, HP + Attack + Defense + SpecialAttack + SpecialDefense + Speed, nameof(HP));
        public int Attack { get; } = CheckRange(Attack, HP + Attack + Defense + SpecialAttack + SpecialDefense + Speed, nameof(Attack));
        public int Defense { get; } = CheckRange(Defense, HP + Attack + Defense + SpecialAttack + SpecialDefense + Speed, nameof(Defense));
        public int SpecialAttack { get; } = CheckRange(SpecialAttack, HP + Attack + Defense + SpecialAttack + SpecialDefense + Speed, nameof(SpecialAttack));
        public int SpecialDefense { get; } = CheckRange(SpecialDefense, HP + Attack + Defense + SpecialAttack + SpecialDefense + Speed, nameof(SpecialDefense));
        public int Speed { get; } = CheckRange(Speed, HP + Attack + Defense + SpecialAttack + SpecialDefense + Speed, nameof(Speed));

        private static int CheckRange(int stat, int accumulated, string statName)
        {
            if (stat < Minimum || stat > Maximum)
            {
                throw new ArgumentException($"Effort value must be in range {Minimum}-{Maximum}, but got {stat}", statName);
            }
            if (accumulated > AccumulatedMaximum)
            {
                throw new ArgumentException($"Accumulated effort values must not exceed {AccumulatedMaximum}, got {accumulated}", nameof(accumulated));
            }
            return stat;
        }
    }
}
