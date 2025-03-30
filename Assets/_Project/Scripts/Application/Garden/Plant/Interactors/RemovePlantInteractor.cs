using System;
using Game.Domain.GardenScope;

namespace Game.Application.GardenScope
{
    public class RemovePlantInteractor : IPlantInteractor
    {
        private readonly Garden _garden;

        public RemovePlantInteractor(Garden garden)
        {
            _garden = garden;
        }

        public void Execute(Guid cellId)
        {
            PlantState state = _garden.GetCellState(cellId);

            if (state != PlantState.Fruit && state != PlantState.DeadSprout) return;
            _garden.RemovePlant(cellId);
        }
    }
}
