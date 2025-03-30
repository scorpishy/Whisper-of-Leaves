using System;
using Game.Application.GardenScope;
using Game.Application.InventoryScope;
using Game.Domain.InventoryScope;

namespace Game.Presentation.GardenScope
{
    public class GardenCellPresenter
    {
        private readonly PlantSeedInteractor _plantSeedInteractor;
        private readonly WaterPlantInteractor _waterPlantInteractor;
        private readonly RemovePlantInteractor _removePlantInteractor;
        private readonly SelectedItemInteractor _selectedItemInteractor;

        public GardenCellPresenter(
            SelectedItemInteractor selectedItemInteractor,
            PlantSeedInteractor plantSeedInteractor,
            WaterPlantInteractor waterPlantInteractor,
            RemovePlantInteractor removePlantInteractor)
        {
            _selectedItemInteractor = selectedItemInteractor;
            _plantSeedInteractor = plantSeedInteractor;
            _waterPlantInteractor = waterPlantInteractor;
            _removePlantInteractor = removePlantInteractor;
        }

        public void ExecuteCellAction(Guid cellId)
        {
            switch (_selectedItemInteractor.SelectedItem)
            {
                case ItemType.Seed:
                    _plantSeedInteractor.Execute(cellId);
                    break;
                case ItemType.WateringCan:
                    _waterPlantInteractor.Execute(cellId);
                    break;
                case ItemType.Shovel:
                    _removePlantInteractor.Execute(cellId);
                    break;
            }

            _selectedItemInteractor.SetSelectedItem(ItemType.None);
        }
    }
}
