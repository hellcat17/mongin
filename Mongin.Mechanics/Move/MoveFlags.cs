namespace Mongin.Mechanics.Move
{
    [Flags]
    public enum MoveFlags
    {
        None = 0,
        MakesContact = (1 << 0),
        AffectedByProtect = (1 << 1),
        AffectedByKingsRock = (1 << 2),
        IsPunch = (1 << 3),
        IsBite = (1 << 4),
        IsBullet = (1 << 5),
        IsSound = (1 << 6),
        IsPulse = (1 << 7),
    }
}