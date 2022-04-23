namespace Mongin.Mechanics.Experience
{
    /// <summary>
    /// Growth implementation for Generation 5.
    /// </summary>
    public class GenVGrowth : IGrowth
    {
        public int GetTotalExperience(GrowthRate rate, Level target) => ExperienceTable[rate][target.Value];

        public int GetMaximumExperience(GrowthRate rate) => GetTotalExperience(rate, new(Level.Maximum));

        public int GetMissingExperience(GrowthRate rate, int currentExp, Level target)
        {
            var total = GetTotalExperience(rate, target);
            return currentExp > total ? 0 : total - currentExp;
        }

        public double GetExperienceProgress(GrowthRate rate, int currentExp, Level current)
        {
            if (current.Value == Level.Maximum)
            {
                return 0.0;
            }

            var prevExp = GetTotalExperience(rate, current);
            var nextExp = GetTotalExperience(rate, new(current.Value + 1));
            var gained = currentExp - prevExp;
            var missing = nextExp - prevExp;
            return (double)gained / missing;
        }

        private readonly static Dictionary<GrowthRate, int[]> ExperienceTable = new()
        {
            { GrowthRate.Erratic, MakeEXPTable(GrowthRate.Erratic) },
            { GrowthRate.Fast, MakeEXPTable(GrowthRate.Fast) },
            { GrowthRate.MediumFast, MakeEXPTable(GrowthRate.MediumFast) },
            { GrowthRate.MediumSlow, MakeEXPTable(GrowthRate.MediumSlow) },
            { GrowthRate.Slow, MakeEXPTable(GrowthRate.Slow) },
            { GrowthRate.Fluctuating, MakeEXPTable(GrowthRate.Fluctuating) },
        };

        private static int[] MakeEXPTable(GrowthRate rate)
        {
            int[] table = new int[Level.Maximum + 1];
            for (int i = 0; i <= Level.Maximum; i++)
            {
                table[i] = GrowthFunctions.GetExperience(rate, i);
            }
            return table;
        }

        internal static class GrowthFunctions
        {
            private static int Erratic(int x)
            {
                if (x >= 1 && x < 50)
                {
                    return (x * x * x * (100 - x)) / 50;
                }
                else if (x >= 50 && x < 68)
                {
                    return (x * x * x * (150 - x)) / 100;
                }
                else if (x >= 68 && x < 98)
                {
                    return (x * x * x * ((1911 - 10 * x) / 3)) / 500;
                }
                else if (x >= 98 && x <= 100)
                {
                    return (x * x * x * (160 - x)) / 100;
                }
                return 0;
            }

            private static int Fast(int x) => (int)(0.8 * x * x * x);

            private static int MediumFast(int x) => x * x * x;

            private static int MediumSlow(int x) => (int)((1.2 * x * x * x) - (15 * x * x) + (100 * x) - 140);

            private static int Slow(int x) => (int)(1.25 * x * x * x);

            private static int Fluctuating(int x)
            {
                if (x >= 1 && x < 15)
                {
                    return (int)(x * x * x * ((((x + 1) / 3.0) + 24) / 50.0));
                }
                else if (x >= 15 && x < 36)
                {
                    return (int)(x * x * x * ((x + 14) / 50.0));
                }
                else if (x >= 36 && x <= 100)
                {
                    return (int)(x * x * x * ((x / 2.0 + 32) / 50));
                }
                return 0;
            }

            internal static int GetExperience(GrowthRate rate, int level) =>
                rate switch
                {
                    GrowthRate.Erratic => Erratic(level),
                    GrowthRate.Fast => Fast(level),
                    GrowthRate.MediumFast => MediumFast(level),
                    GrowthRate.MediumSlow => MediumSlow(level),
                    GrowthRate.Slow => Slow(level),
                    GrowthRate.Fluctuating => Fluctuating(level),
                    _ => 0,
                };


        }
    }
}