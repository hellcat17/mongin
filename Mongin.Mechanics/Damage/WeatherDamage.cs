using Mongin.Mechanics.Utils;

namespace Mongin.Mechanics.Damage
{
    public class WeatherDamage
    {
        /// <summary>
        /// Get the base damage multiplier for a move used in a weather condition.
        /// </summary>
        /// <param name="condition">Weather condition move is used in</param>
        /// <param name="move">Typing of the move</param>
        /// <returns>Multiplier for base damage calculation</returns>
        public static double GetDamageMultiplier(Weather condition, Typing move)
        {
            if (condition == Weather.Rain)
            {
                if (move == Typing.Water)
                {
                    return 2.0;
                }
                else if (move == Typing.Fire)
                {
                    return 0.5;
                }
            }
            else if (condition == Weather.Sunshine)
            {
                if (move == Typing.Fire)
                {
                    return 2.0;
                }
                else if (move == Typing.Water)
                {
                    return 0.5;
                }
            }
            return 1.0;
        }

        /// <summary>
        /// Get the absolute amount of damage for a specimen in a specific weather condition.
        /// </summary>
        /// <param name="condition">Weather condition</param>
        /// <param name="primary">Primary type of the specimen</param>
        /// <param name="secondary">Optional secondary type of the specimen</param>
        /// <param name="maxHP">Maximum HP (effective HP stat) of the specimen</param>
        /// <returns>Absolute damage received</returns>
        public static int GetDamagePerTurn(Weather condition, Typing primary, Optional<Typing> secondary, int maxHP)
        {
            if (ReceivesWeatherDamage(condition, primary, secondary))
            {
                return (int)PokeMath.Round(maxHP / 16.0);
            }
            return 0;
        }

        private readonly static Typing[] HailResistentTypes = { Typing.Ice };
        private readonly static Typing[] SandstormResistentTypes = { Typing.Rock, Typing.Ground, Typing.Steel };

        private static bool ContainsResistentType(Typing[] resists, Typing primary, Optional<Typing> secondary)
            => Array.IndexOf(resists, primary) != -1
            || secondary.Map<int>(t => Array.IndexOf(resists, t)).GetValueOr(-1) != -1;


        private static bool ReceivesWeatherDamage(Weather condition, Typing primary, Optional<Typing> secondary)
            => condition switch
            {
                Weather.Hail => !ContainsResistentType(HailResistentTypes, primary, secondary),
                Weather.Sandstorm => !ContainsResistentType(SandstormResistentTypes, primary, secondary),
                _ => false
            };
    }
}