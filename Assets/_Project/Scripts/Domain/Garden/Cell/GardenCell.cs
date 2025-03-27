using System;
using Game.Domain.Plant;

namespace Game.Domain.Garden
{
    public class GardenCell : IGardenCell
    {
        private readonly Func<IPlant> _plantFactory;

        public IPlant Plant { get; private set; }
        public bool IsEmpty => Plant == null;

        public event Action<PlantState> OnStateChanged;
        public event Action<PlantState> OnPlantRemoved;

        public GardenCell(Func<IPlant> plantFactory)
        {
            _plantFactory = plantFactory;
        }

        public void PlantSeed()
        {
            if (!IsEmpty) return;

            Plant = _plantFactory();
            OnStateChanged?.Invoke(Plant.State);
        }

        public void Grow()
        {
            if (IsEmpty) return;

            Plant.Grow();
            OnStateChanged?.Invoke(Plant.State);
        }

        public void Wither()
        {
            if (IsEmpty) return;

            Plant.Wither();
            OnStateChanged?.Invoke(Plant.State);
        }

        public void Remove()
        {
            if (IsEmpty) return;

            OnPlantRemoved?.Invoke(Plant.State);
            Plant = null;
            OnStateChanged?.Invoke(PlantState.None);
        }
    }
}
