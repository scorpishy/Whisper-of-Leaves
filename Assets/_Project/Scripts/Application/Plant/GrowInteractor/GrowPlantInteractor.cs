using Game.Application.Timer;
using Game.Domain.Garden;
using Game.Domain.Plant;

namespace Game.Application.Plant
{
    public class GrowPlantInteractor : IGrowPlantInteractor
    {
        private readonly ITimerService _timer;

        public GrowPlantInteractor(ITimerService timer)
        {
            _timer = timer;
        }

        public void Execute(IGardenCell cell)
        {
            if (cell.IsEmpty || cell.Plant.State != PlantState.Sprout) return;

            _timer.StartTimer(20f, () =>
            {
                if (cell.IsEmpty || cell.Plant.State != PlantState.Sprout) return;
                cell.Wither();
            });
        }
    }
}
