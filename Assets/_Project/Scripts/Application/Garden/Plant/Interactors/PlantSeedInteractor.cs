using System;
using Game.Application.TimerScope;
using Game.Domain.GardenScope;

namespace Game.Application.GardenScope
{
    public class PlantSeedInteractor : IPlantInteractor
    {
        private readonly ITimer _timer;
        private readonly GrowPlantInteractor _growPlantInteractor;
        private readonly Garden _garden;

        public PlantSeedInteractor(ITimer timer, GrowPlantInteractor growPlantInteractor, Garden garden)
        {
            _timer = timer;
            _growPlantInteractor = growPlantInteractor;
            _garden = garden;
        }

        public void Execute(Guid cellId)
        {
            if (_garden.GetCellState(cellId) != PlantState.None) return;

            _garden.PlantSeed(cellId);

            _timer.StartTimer(10f, () =>
            {
                if (_garden.GetCellState(cellId) != PlantState.Seed) return;
                _garden.GrowPlant(cellId);
                _growPlantInteractor.Execute(cellId);
            });
        }
    }
}
