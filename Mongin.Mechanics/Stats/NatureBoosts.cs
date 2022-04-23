﻿namespace Mongin.Mechanics.Stats
{
    public enum NatureStatChange
    {
        Unaffected,
        Boosted,
        Weakened,
    }

    public static class NatureBoosts
    {
        public static NatureStatChange Get(Nature nature, StatName stat)
            => stat != StatName.HP ? Boosts[nature][stat] : throw new ArgumentException("HP cannot have a nature-induced boost", nameof(stat));

        private readonly static Dictionary<Nature, Dictionary<StatName, NatureStatChange>> Boosts = new()
        {
            {
                Nature.Adamant,
                new()
                {
                    {
                        StatName.Attack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Defense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialAttack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialDefense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Speed,
                        NatureStatChange.Unaffected
                    },
                }
            },

            {
                Nature.Bashful,
                new()
                {
                    {
                        StatName.Attack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Defense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialAttack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialDefense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Speed,
                        NatureStatChange.Unaffected
                    },
                }
            },

            {
                Nature.Bold,
                new()
                {
                    {
                        StatName.Attack,
                        NatureStatChange.Weakened
                    },
                    {
                        StatName.Defense,
                        NatureStatChange.Boosted
                    },
                    {
                        StatName.SpecialAttack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialDefense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Speed,
                        NatureStatChange.Unaffected
                    },
                }
            },

            {
                Nature.Brave,
                new()
                {
                    {
                        StatName.Attack,
                        NatureStatChange.Boosted
                    },
                    {
                        StatName.Defense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialAttack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialDefense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Speed,
                        NatureStatChange.Weakened
                    },
                }
            },

            {
                Nature.Calm,
                new()
                {
                    {
                        StatName.Attack,
                        NatureStatChange.Weakened
                    },
                    {
                        StatName.Defense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialAttack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialDefense,
                        NatureStatChange.Boosted
                    },
                    {
                        StatName.Speed,
                        NatureStatChange.Unaffected
                    },
                }
            },

            {
                Nature.Careful,
                new()
                {
                    {
                        StatName.Attack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Defense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialAttack,
                        NatureStatChange.Weakened
                    },
                    {
                        StatName.SpecialDefense,
                        NatureStatChange.Boosted
                    },
                    {
                        StatName.Speed,
                        NatureStatChange.Unaffected
                    },
                }
            },

            {
                Nature.Docile,
                new()
                {
                    {
                        StatName.Attack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Defense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialAttack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialDefense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Speed,
                        NatureStatChange.Unaffected
                    },
                }
            },

            {
                Nature.Gentle,
                new()
                {
                    {
                        StatName.Attack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Defense,
                        NatureStatChange.Weakened
                    },
                    {
                        StatName.SpecialAttack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialDefense,
                        NatureStatChange.Boosted
                    },
                    {
                        StatName.Speed,
                        NatureStatChange.Unaffected
                    },
                }
            },

            {
                Nature.Hardy,
                new()
                {
                    {
                        StatName.Attack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Defense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialAttack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialDefense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Speed,
                        NatureStatChange.Unaffected
                    },
                }
            },

            {
                Nature.Hasty,
                new()
                {
                    {
                        StatName.Attack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Defense,
                        NatureStatChange.Weakened
                    },
                    {
                        StatName.SpecialAttack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialDefense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Speed,
                        NatureStatChange.Boosted
                    },
                }
            },

            {
                Nature.Impish,
                new()
                {
                    {
                        StatName.Attack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Defense,
                        NatureStatChange.Boosted
                    },
                    {
                        StatName.SpecialAttack,
                        NatureStatChange.Weakened
                    },
                    {
                        StatName.SpecialDefense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Speed,
                        NatureStatChange.Unaffected
                    },
                }
            },

            {
                Nature.Jolly,
                new()
                {
                    {
                        StatName.Attack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Defense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialAttack,
                        NatureStatChange.Weakened
                    },
                    {
                        StatName.SpecialDefense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Speed,
                        NatureStatChange.Boosted
                    },
                }
            },

            {
                Nature.Lax,
                new()
                {
                    {
                        StatName.Attack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Defense,
                        NatureStatChange.Boosted
                    },
                    {
                        StatName.SpecialAttack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialDefense,
                        NatureStatChange.Weakened
                    },
                    {
                        StatName.Speed,
                        NatureStatChange.Unaffected
                    },
                }
            },

            {
                Nature.Lonely,
                new()
                {
                    {
                        StatName.Attack,
                        NatureStatChange.Boosted
                    },
                    {
                        StatName.Defense,
                        NatureStatChange.Weakened
                    },
                    {
                        StatName.SpecialAttack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialDefense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Speed,
                        NatureStatChange.Unaffected
                    },
                }
            },

            {
                Nature.Mild,
                new()
                {
                    {
                        StatName.Attack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Defense,
                        NatureStatChange.Weakened
                    },
                    {
                        StatName.SpecialAttack,
                        NatureStatChange.Boosted
                    },
                    {
                        StatName.SpecialDefense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Speed,
                        NatureStatChange.Unaffected
                    },
                }
            },

            {
                Nature.Modest,
                new()
                {
                    {
                        StatName.Attack,
                        NatureStatChange.Weakened
                    },
                    {
                        StatName.Defense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialAttack,
                        NatureStatChange.Boosted
                    },
                    {
                        StatName.SpecialDefense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Speed,
                        NatureStatChange.Unaffected
                    },
                }
            },

            {
                Nature.Naive,
                new()
                {
                    {
                        StatName.Attack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Defense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialAttack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialDefense,
                        NatureStatChange.Weakened
                    },
                    {
                        StatName.Speed,
                        NatureStatChange.Boosted
                    },
                }
            },

            {
                Nature.Naughty,
                new()
                {
                    {
                        StatName.Attack,
                        NatureStatChange.Boosted
                    },
                    {
                        StatName.Defense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialAttack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialDefense,
                        NatureStatChange.Weakened
                    },
                    {
                        StatName.Speed,
                        NatureStatChange.Unaffected
                    },
                }
            },

            {
                Nature.Quiet,
                new()
                {
                    {
                        StatName.Attack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Defense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialAttack,
                        NatureStatChange.Boosted
                    },
                    {
                        StatName.SpecialDefense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Speed,
                        NatureStatChange.Weakened
                    },
                }
            },

            {
                Nature.Quirky,
                new()
                {
                    {
                        StatName.Attack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Defense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialAttack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialDefense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Speed,
                        NatureStatChange.Unaffected
                    },
                }
            },

            {
                Nature.Rash,
                new()
                {
                    {
                        StatName.Attack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Defense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialAttack,
                        NatureStatChange.Boosted
                    },
                    {
                        StatName.SpecialDefense,
                        NatureStatChange.Weakened
                    },
                    {
                        StatName.Speed,
                        NatureStatChange.Unaffected
                    },
                }
            },

            {
                Nature.Relaxed,
                new()
                {
                    {
                        StatName.Attack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Defense,
                        NatureStatChange.Boosted
                    },
                    {
                        StatName.SpecialAttack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialDefense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Speed,
                        NatureStatChange.Weakened
                    },
                }
            },

            {
                Nature.Sassy,
                new()
                {
                    {
                        StatName.Attack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Defense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialAttack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialDefense,
                        NatureStatChange.Boosted
                    },
                    {
                        StatName.Speed,
                        NatureStatChange.Weakened
                    },
                }
            },

            {
                Nature.Serious,
                new()
                {
                    {
                        StatName.Attack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Defense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialAttack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialDefense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Speed,
                        NatureStatChange.Unaffected
                    },
                }
            },

            {
                Nature.Timid,
                new()
                {
                    {
                        StatName.Attack,
                        NatureStatChange.Weakened
                    },
                    {
                        StatName.Defense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialAttack,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.SpecialDefense,
                        NatureStatChange.Unaffected
                    },
                    {
                        StatName.Speed,
                        NatureStatChange.Boosted
                    },
                }
            },
        };
    }
}