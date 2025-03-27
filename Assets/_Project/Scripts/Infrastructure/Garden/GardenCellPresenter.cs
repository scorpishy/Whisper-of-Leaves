using Game.Application.Plant;
using Game.Domain.Garden;
using Game.Domain.Inventory;
using Game.Infrastructure.Inventory;

namespace Game.Infrastructure.Garden
{
    public class GardenCellPresenter : IGardenCellPresenter
    {
        private readonly IPlantSeedInteractor _plantSeedInteractor;
        private readonly IWaterPlantInteractor _waterPlantInteractor;
        private readonly IRemovePlantInteractor _removePlantInteractor;
        private readonly ISelectedItemService _selectedItemService;

        public GardenCellPresenter(
            ISelectedItemService selectedItemService,
            IPlantSeedInteractor plantSeedInteractor,
            IWaterPlantInteractor waterPlantInteractor,
            IRemovePlantInteractor removePlantInteractor)
        {
            _selectedItemService = selectedItemService;
            _plantSeedInteractor = plantSeedInteractor;
            _waterPlantInteractor = waterPlantInteractor;
            _removePlantInteractor = removePlantInteractor;
        }

        public void ExecuteCellAction(IGardenCell cell)
        {
            switch (_selectedItemService.SelectedItem)
            {
                case ItemType.Seed:
                    _plantSeedInteractor.Execute(cell);
                    break;
                case ItemType.WateringCan:
                    _waterPlantInteractor.Execute(cell);
                    break;
                case ItemType.Shovel:
                    _removePlantInteractor.Execute(cell);
                    break;
            }

            _selectedItemService.SetSelectedItem(ItemType.None);
        }
    }
}
