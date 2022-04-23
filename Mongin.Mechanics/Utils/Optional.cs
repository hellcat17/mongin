namespace Mongin.Mechanics.Utils
{
    /// <summary>
    /// An optional value that might or might not contain a value.
    /// </summary>
    public class Optional<T>
    {
        private readonly T? value_;

        public Optional()
        {
            value_ = default;
        }

        public Optional(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), "Cannot initialize Optional<T> with null");
            }

            value_ = value;
        }

        public bool HasValue { get => value_ != null; }

        public T GetValue() => value_ ?? throw new NullReferenceException("Cannot access value of empty Optional<T>");

        public T GetValueOr(T fallback) => value_ ?? fallback;

        public Optional<T2> Map<T2>(Func<T, Optional<T2>> mapper) => value_ != null ? mapper(value_) : new();

        public Optional<T> Map(Func<T, Optional<T>> mapper) => Map<T>(mapper);

        public static implicit operator Optional<T>(T value) => new(value);
    }
}