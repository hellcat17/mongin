namespace Mongin.Mechanics.Move
{
    public enum MoveTeachResult
    {
        Success,
        TooManyTaught,
        AlreadyTaught,
    }

    public class Moveset
    {
        public const int MinimumAmount = 1;
        public const int MaximumAmount = 4;

        private List<IMove> _moves;
        public IReadOnlyCollection<IMove> Moves
        {
            get { return _moves; }
        }

        public Moveset(IReadOnlyCollection<IMove> moves)
        {
            if (moves.Count < MinimumAmount || moves.Count > MaximumAmount)
            {
                throw new ArgumentException($"Moveset size must be between {MinimumAmount} and {MaximumAmount}, but got {moves.Count}", nameof(moves));
            }

            _moves = new List<IMove>(moves);
        }

        /// <summary>
        /// Get the default moveset for a species at the given level.
        /// </summary>
        public static Moveset GetDefault(Species.Species species, Level level)
        {
            Queue<IMove> moves = new();
            for (int lvl = Level.Minimum; lvl <= level.Value; lvl++)
            {
                if (species.Learnset.TryGetValue(new(lvl), out var learned))
                {
                    foreach (IMove move in learned)
                    {
                        if (moves.Count == MaximumAmount)
                        {
                            moves.Dequeue();
                        }
                        moves.Enqueue(move);
                    }
                }
            }
            return new(moves);
        }

        /// <summary>
        /// Teach a species a move.
        /// </summary>
        public MoveTeachResult Teach(IMove move)
        {
            if (_moves.Count == MaximumAmount)
            {
                return MoveTeachResult.TooManyTaught;
            }

            if (_moves.Contains(move))
            {
                return MoveTeachResult.AlreadyTaught;
            }

            _moves.Add(move);
            return MoveTeachResult.Success;
        }

        /// <summary>
        /// Have a species forget a move.
        /// </summary>
        /// <returns>false if only one move left</returns>
        public bool Forget(IMove move)
        {
            if (_moves.Count == MinimumAmount)
            {
                return false;
            }

            if (_moves.Remove(move) == false)
            {
                throw new ArgumentException($"Move '{move.Name}' is not contained within this moveset", nameof(move));
            }

            return true;
        }

        /// <summary>
        /// Swap the positions of two moves.
        /// </summary>
        public void Swap(IMove m1, IMove m2)
        {
            int i1 = _moves.IndexOf(m1);
            if (i1 == -1)
            {
                throw new ArgumentException($"Move '{m1.Name}' is not contained within this moveset", nameof(m1));
            }

            int i2 = _moves.IndexOf(m2);
            if (i2 == -1)
            {
                throw new ArgumentException($"Move '{m2.Name}' is not contained within this moveset", nameof(m2));
            }

            _moves[i1] = m2;
            _moves[i2] = m1;
        }
    }
}