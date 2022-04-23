namespace Mongin.Mechanics.Stats
{
    /// <summary>
    /// Base stats that are equal for every specimen of a species.
    /// </summary>
    public record BaseStats
    {
        public int HP { get; init; }
        public int Attack { get; init; }
        public int Defense { get; init; }
        public int SpecialAttack { get; init; }
        public int SpecialDefense { get; init; }
        public int Speed { get; init; }
    }
}
