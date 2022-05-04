namespace Mongin.Mechanics.Battle
{
    public interface ISide
    {
        /// <summary>
        /// Local state for this side of the field.
        /// </summary>
        IBattleState State { get; }

        /// <summary>
        /// Get the whole party for this side of the field.
        /// </summary>
        IReadOnlyCollection<IBattleParticipant> Party { get; }

        /// <summary>
        /// Partipants currently on the field.
        /// </summary>
        IReadOnlyCollection<IBattleParticipant> Participants { get; }
    }

    public interface IBattleField
    {
        /// <summary>
        /// State for the whole field. Also see <seealso cref="CommonFieldStates"/>.
        /// </summary>
        IBattleState State { get; }

        /// <summary>
        /// State for the currently attacking side.
        /// </summary>
        ISide AttackerSide { get; }

        /// <summary>
        /// State for the currently defending side.
        /// </summary>
        ISide DefenderSide { get; }
    }

    public static class CommonFieldStates
    {
        public readonly static State Weather = new("weather");
    }
}
