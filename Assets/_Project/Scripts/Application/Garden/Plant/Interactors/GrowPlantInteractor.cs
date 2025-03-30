using System;
using Game.Application.TimerScope;
using Game.Domain.GardenScope;

namespace Game.Application.GardenScope
{
    public class GrowPlantInteractor : IPlantInteractor
    {
        private readonly ITimer _timer;
        private readonly Garden _garden;

        public GrowPlantInteractor(ITimer timer, Garden garden)
        {
            _timer = timer;
            _garden = garden;
        }

        public void Execute(Guid cellId)
        {
            if (_garden.GetCellState(cellId) != PlantState.Sprout) return;

            _timer.StartTimer(20f, () =>
            {
                if (_garden.GetCellState(cellId) != PlantState.Sprout) return;
                _garden.WitherPlant(cellId);
            });
        }
    }
}
