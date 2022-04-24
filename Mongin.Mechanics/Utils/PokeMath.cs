namespace Mongin.Mechanics.Utils
{
    public static class PokeMath
    {
        public static double Round(double val)
        {
            return val % 1 > 0.5 ? Math.Ceiling(val) : Math.Floor(val);
        }
    }
}