namespace Mongin.Mechanics.Species
{
    public interface IAbility
    {
        bool IsHidden { get; }
        int Id { get; }
        string Name { get; }
    }
}