using Game.Domain.Garden;
using Game.Domain.Plant;

namespace Game.Application.Plant
{
    public class RemovePlantInterator : IRemovePlantInteractor
    {
        public void Execute(IGardenCell cell)
        {
            bool isHarvest = cell.Plant.State == PlantState.Fruit || cell.Plant.State == PlantState.DeadSprout;
            if (cell.IsEmpty || !isHarvest) return;

            cell.Remove();
        }
    }
}
