namespace Mongin.Mechanics.Species
{
    public enum StatusCondition
    {
        Burn,
        Freeze,
        Paralysis,
        Poison,
        Toxic,
        Sleep,
    }

    [Flags]
    public enum VolatileStatusCondition
    {
        None = (1 << 0),
        Flinch = (1 << 1),
        Confusion = (1 << 2),
        Infatuation = (1 << 3),
        LeechSeed = (1 << 4),
    }
}