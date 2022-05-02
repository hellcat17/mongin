namespace Mongin.Mechanics.Move
{
    /// <summary>
    /// The amount of possible hits for a move. Will randomly hit between
    /// Minimum and Maximum, set them to the same value for a fixed amount.
    /// </summary>
    public record HitCount
    {
        public int Minimum { get; init; } = 1;
        public int Maximum { get; init; } = 1;
    }

    public interface IMove
    {
        Typing Typing { get; }
        MoveCategory Category { get; }
        MoveFlags Flags { get; }
        MoveTarget Target { get; }
        int BasePower { get; }
        int Priority { get; }
        HitCount HitCount { get; }
        int Id { get; }
        string Name { get; }
    }
}
