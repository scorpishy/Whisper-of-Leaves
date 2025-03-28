using System;
using Game.Domain.Common;
using Game.Domain.Plant;

namespace Game.Domain.Garden
{
    public interface IGardenCell : IIdentifiable
    {
        IPlant Plant { get; }
        bool IsEmpty { get; }

        event Action<PlantState> OnStateChanged;
        event Action<PlantState> OnPlantRemoved;

        void PlantSeed();
        void Grow();
        void Wither();
        void Remove();
    }
}
