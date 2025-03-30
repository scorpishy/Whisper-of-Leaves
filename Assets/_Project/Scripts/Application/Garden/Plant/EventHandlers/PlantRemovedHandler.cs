using Game.Application.HarvestScope;
using Game.Domain.GardenScope;
using Game.Domain.HarvestScope;
using System;

namespace Game.Application.GardenScope
{
    public class PlantRemovedHandler : IDisposable
    {
        private readonly HarvestInteractor _harvestInteractor;
        private readonly Garden _garden;

        public PlantRemovedHandler(HarvestInteractor harvestInteractor, Garden garden)
        {
            _harvestInteractor = harvestInteractor;
            _garden = garden;
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            foreach (GardenCell cell in _garden.Cells.Values)
            {
                cell.OnPlantRemoved += OnPlantRemoved;
            }
        }

        private void OnPlantRemoved(PlantState state)
        {
            HarvestedItemType type = state.ToHarvestedItemType();
            if (type == HarvestedItemType.None) return;
            _harvestInteractor.AddHarvest(type);
        }

        public void Dispose()
        {
            foreach (GardenCell cell in _garden.Cells.Values)
            {
                cell.OnPlantRemoved -= OnPlantRemoved;
            }
        }
    }
}