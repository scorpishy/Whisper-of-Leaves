using Game.Application.Timer;
using Game.Domain.Garden;
using Game.Domain.Plant;

namespace Game.Application.Plant
{
    public class PlantSeedInteractor : IPlantSeedInteractor
    {
        private readonly ITimerService _timer;
        private readonly IGrowPlantInteractor _growPlantInteractor;

        public PlantSeedInteractor(ITimerService timer, IGrowPlantInteractor growPlantInteractor)
        {
            _timer = timer;
            _growPlantInteractor = growPlantInteractor;
        }

        public void Execute(IGardenCell cell)
        {
            if (!cell.IsEmpty) return;

            cell.PlantSeed();

            _timer.StartTimer(10f, () =>
            {
                if (cell.IsEmpty || cell.Plant.State != PlantState.Seed) return;
                cell.Grow();
                _growPlantInteractor.Execute(cell);
            });
        }
    }
}
