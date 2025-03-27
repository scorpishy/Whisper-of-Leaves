namespace Game.Domain.Plant
{
    public interface IPlant
    {
        PlantState State { get; }

        void Grow();
        void Wither();
    }
}
