using System;
using Game.Domain.Garden;
using Game.Domain.Harvest;
using Game.Domain.Plant;
using UniRx;

namespace Game.Infrastructure.Harvest
{
    public class HarvestService : IHarvestService, IDisposable
    {
        private readonly IHarvestedItem _collectedFruits;
        private readonly IHarvestedItem _deadSprouts;
        private readonly CompositeDisposable _disposables = new();

        public IHarvestedItem CollectedFruits => _collectedFruits;
        public IHarvestedItem DeadSprouts => _deadSprouts;

        public HarvestService(Func<HarvestedItemType, IHarvestedItem> harvestItemFactory, IGarden garden)
        {
            _collectedFruits = harvestItemFactory(HarvestedItemType.Fruit);
            _deadSprouts = harvestItemFactory(HarvestedItemType.DeadSprout);

            foreach (IGardenCell cell in garden.Cells)
            {
                ObserveCellRemovals(cell);
            }
        }

        private void ObserveCellRemovals(IGardenCell cell)
        {
            Observable.FromEvent<PlantState>(
                h => cell.OnPlantRemoved += h,
                h => cell.OnPlantRemoved -= h
            )
            .Subscribe(HandlePlantRemoval)
            .AddTo(_disposables);
        }

        private void HandlePlantRemoval(PlantState state)
        {
            switch (state)
            {
                case PlantState.Fruit:
                    _collectedFruits.Add(1);
                    break;
                case PlantState.DeadSprout:
                    _deadSprouts.Add(1);
                    break;
            }
        }

        public void Dispose() => _disposables.Dispose();
    }
}
