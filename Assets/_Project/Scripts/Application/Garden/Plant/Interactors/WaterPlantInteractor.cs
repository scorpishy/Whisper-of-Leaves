using System;
using Game.Domain.GardenScope;

namespace Game.Application.GardenScope
{
    public class WaterPlantInteractor : IPlantInteractor
    {
        private readonly Garden _garden;

        public WaterPlantInteractor(Garden garden)
        {
            _garden = garden;
        }

        public void Execute(Guid cellId)
        {
            if (_garden.GetCellState(cellId) != PlantState.Sprout) return;
            _garden.GrowPlant(cellId);
        }
    }
}
