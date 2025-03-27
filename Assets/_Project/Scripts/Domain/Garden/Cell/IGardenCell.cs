using System;
using Game.Domain.Plant;

namespace Game.Domain.Garden
{
    public interface IGardenCell
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
