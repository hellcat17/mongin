using Mongin.Mechanics.Item;
using Mongin.Mechanics.Species;
using Mongin.Mechanics.Stats;

namespace Mongin.Mechanics.Battle
{
    /// <summary>
    /// Interface to a participant in a battle. Implementations should behave
    /// according to their underlying battle type and conditions.
    /// </summary>
    public interface IBattleParticipant
    {
        /// <summary>
        /// Underlying species.
        /// </summary>
        Species.Species Species { get; }

        /// <summary>
        /// Current ability of the specimen.
        /// </summary>
        IAbility Ability { get; }

        /// <summary>
        /// Currently held item of the specimen.
        /// </summary>
        IItem HeldItem { get; }

        /// <summary>
        /// Effective stats used for damage calculation, including boosts.
        /// </summary>
        EffectiveStats Stats { get; }

        /// <summary>
        /// Remaining health points. Zero if the specimen fainted.
        /// </summary>
        int HealthPoints { get; }

        /// <summary>
        /// Current permanent status condition.
        /// </summary>
        StatusCondition StatusCondition { get; }

        /// <summary>
        /// One or more volatile status conditions.
        /// </summary>
        VolatileStatusCondition VolatileStatusCondition { get; }

        void ChangeForm(Species.Species form);

        void ChangeAbility(IAbility ability);

        void ChangeHeldItem(IItem heldItem);

        void RemoveHeldItem();

        void ApplyBoosts(TemporaryBoosts boosts);

        void ClearBoosts();

        void ChangeHealthPoints(int health);

        void InflictStatusCondition(StatusCondition condition);

        void InflictStatusCondition(VolatileStatusCondition condition);

        void ClearStatusCondition();

        void ClearStatusCondition(VolatileStatusCondition condition);
    }
}