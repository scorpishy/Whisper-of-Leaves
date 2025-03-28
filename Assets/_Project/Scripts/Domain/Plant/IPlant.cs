using Game.Domain.Common;

namespace Game.Domain.Plant
{
    public interface IPlant : IIdentifiable
    {
        PlantState State { get; }

        void Grow();
        void Wither();
    }
}
