namespace Mongin.Mechanics.Utils
{
    public static class NullableExtensions
    {
        public static T2? Map<T1, T2>(this T1? x, Func<T1, T2> mapping)
            where T1 : class
            where T2 : class
            => x is not null ? mapping(x) : null;

        public static T2? Map<T1, T2>(this T1? x, Func<T1, T2> mapping)
            where T1 : struct
            where T2 : struct
            => x.HasValue ? mapping(x.Value) : null;

        public static T? Filter<T>(this T? x, Func<T, bool> predicate)
            where T : class
            => x != null && predicate(x) ? x : null;

        public static T? Filter<T>(this T? x, Func<T, bool> predicate)
            where T : struct
            => x.HasValue && predicate(x.Value) ? x : null;

        public static T2? Bind<T1, T2>(this T1? x, Func<T1, T2?> binder)
            where T1 : class
            where T2 : class
            => x != null ? binder(x) : null;

        public static T2? Bind<T1, T2>(this T1? x, Func<T1, T2?> binder)
            where T1 : struct
            where T2 : struct
            => x.HasValue ? binder(x.Value) : null;

        public static T2? Bind<T1, T2>(this T1? x, Func<T1, T2?> binder)
            where T1 : class
            where T2 : struct
            => x != null ? binder(x) : null;

        public static T2? Bind<T1, T2>(this T1? x, Func<T1, T2?> binder)
            where T1 : struct
            where T2 : class
            => x.HasValue ? binder(x.Value) : null;
    }

    public static class NullableExtensions2
    {
        public static T2? Map<T1, T2>(this T1? x, Func<T1, T2> mapping)
            where T1 : class
            where T2 : struct
            => x != null ? mapping(x) : null;

        public static T2? Map<T1, T2>(this T1? x, Func<T1, T2> mapping)
            where T1 : struct
            where T2 : class
            => x.HasValue ? mapping(x.Value) : null;
    }
}
