using System;
using Game.Domain.CommonScope;

namespace Game.Domain.GardenScope
{
    public class GardenCell : IIdentifiable
    {
        private readonly Func<Plant> _plantFactory;

        public Guid Id { get; } = Guid.NewGuid();
        public Plant Plant { get; private set; }
        public bool IsEmpty => Plant == null;

        public event Action<PlantState> OnStateChanged;
        public event Action<PlantState> OnPlantRemoved;

        public GardenCell(Func<Plant> plantFactory)
        {
            _plantFactory = plantFactory;
        }

        internal void PlantSeed()
        {
            if (!IsEmpty) return;

            Plant = _plantFactory();
            OnStateChanged?.Invoke(Plant.State);
        }

        internal void Grow()
        {
            if (IsEmpty) return;

            Plant.Grow();
            OnStateChanged?.Invoke(Plant.State);
        }

        internal void Wither()
        {
            if (IsEmpty) return;

            Plant.Wither();
            OnStateChanged?.Invoke(Plant.State);
        }

        internal void Remove()
        {
            if (IsEmpty) return;

            OnPlantRemoved?.Invoke(Plant.State);
            Plant = null;
            OnStateChanged?.Invoke(PlantState.None);
        }
    }
}
