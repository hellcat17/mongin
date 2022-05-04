namespace Mongin.Mechanics.Battle
{
    /// <summary>
    /// A unique state with a human-readable name. Enforces a single source of truth for states.
    /// </summary>
    public class State
    {
        public string Name { get; private set; }

        public State(string name)
        {
            Name = name;
        }
    }

    /// <summary>
    /// An interface for battle state to be used by items, abilities and moves.
    /// </summary>
    public interface IBattleState
    {
        /// <summary>
        /// Get a state. Returns null if nonexistent or not of the given type.
        /// </summary>
        T? Get<T>(State state);

        /// <summary>
        /// Set a state. Returns the old state if exists and is of the given type.
        /// </summary>
        T? Set<T>(State state, T value);

        /// <summary>
        /// Reset the states to their initial value.
        /// </summary>
        void Reset();
    }
}