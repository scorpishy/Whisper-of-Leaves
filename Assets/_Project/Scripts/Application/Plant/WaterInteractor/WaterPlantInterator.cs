using Game.Domain.Garden;
using Game.Domain.Plant;

namespace Game.Application.Plant
{
    public class WaterPlantInterator : IWaterPlantInteractor
    {
        public void Execute(IGardenCell cell)
        {
            if (cell.IsEmpty || cell.Plant.State != PlantState.Sprout) return;

            cell.Grow();
        }
    }
}
