using Mongin.Mechanics.Experience;
using Mongin.Mechanics.Move;
using Mongin.Mechanics.Stats;
using Mongin.Mechanics.Utils;
using System.Collections.Immutable;

namespace Mongin.Mechanics.Species
{
    public record Species
    {
        public Typing PrimaryType { get; init; }
        public Optional<Typing> SecondaryType { get; init; } = new();
        public BaseStats BaseStats { get; init; } = new();
        public ImmutableArray<IAbility> Abilities { get; init; }
        public ImmutableDictionary<Level, ImmutableArray<IMove>> Learnset { get; init; } = ImmutableDictionary<Level, ImmutableArray<IMove>>.Empty;
        public GrowthRate GrowthRate { get; init; }
        public EffortValueYield EVYield { get; init; } = new(0, 0, 0, 0, 0);
        public int ExperienceYield { get; init; }
        public CatchRate BaseCatchRate { get; init; } = new(255);
        public Ratio<Gender> GenderRatio { get; init; } = new(Gender.Male, new(0.5), Gender.Female);
        public Friendship BaseFriendship { get; init; } = new(70);
        /// <summary>
        /// Height in meters
        /// </summary>
        public double Height;
        /// <summary>
        /// Weight in kilograms
        /// </summary>
        public double Weight;
    }
}