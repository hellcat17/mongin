using Mongin.Mechanics.Stats;
using Mongin.Mechanics.Utils;

namespace Mongin.Mechanics.Species
{
    public class Specimen
    {
        public Species Species { get; private set; }
        public IndividualValues Genetics { get; private set; }
        public Nature Nature { get; private set; }
        public Gender Gender { get; private set; }
        public IAbility Ability { get; private set; }
        public Level Level { get; private set; }
        public int ExperiencePoints { get; private set; }
        public EffortValues Effort { get; private set; }
        public Friendship Friendship { get; private set; }

        public int HealthPoints { get; private set; }
        public Optional<StatusCondition> StatusCondition { get; private set; }
        public EffectiveStats Stats
        {
            get { return new EffectiveStats(Species.BaseStats, Genetics, Effort, Level, Nature); }
        }

        public Specimen(
            Species species, IndividualValues ivs, Nature nature, Gender gender, IAbility ability, Level level, int exp,
            EffortValues? evs = null, Friendship? friendShip = null, int? hp = null, StatusCondition? status = null)
        {
            Species = species;
            Genetics = ivs;
            Nature = nature;
            Gender = gender;
            Ability = ability;
            Level = level;
            ExperiencePoints = exp;
            Effort = evs ?? new EffortValues(0, 0, 0, 0, 0, 0);
            Friendship = friendShip ?? species.BaseFriendship;
            HealthPoints = hp ?? new EffectiveStats(species.BaseStats, ivs, Effort, level, nature).HP;
            StatusCondition = status ?? new();
        }
    }
}