using System;
using Game.Domain.HarvestScope;
using UniRx;

namespace Game.Infrastructure.HarvestScope
{
    public class HarvestRepository : IHarvestRepository
    {
        private readonly HarvestedItem _fruits;
        private readonly HarvestedItem _deadSprouts;

        private readonly BehaviorSubject<int> _fruitsQuantity;
        private readonly BehaviorSubject<int> _deadSproutsQuantity;

        public IObservable<int> FruitsQuantity => _fruitsQuantity;
        public IObservable<int> DeadSproutsQuantity => _deadSproutsQuantity;

        public HarvestRepository(Func<HarvestedItemType, HarvestedItem> harvestFactory)
        {
            _fruits = harvestFactory(HarvestedItemType.Fruit);
            _deadSprouts = harvestFactory(HarvestedItemType.DeadSprout);

            _fruitsQuantity = new BehaviorSubject<int>(_fruits.Quantity);
            _deadSproutsQuantity = new BehaviorSubject<int>(_deadSprouts.Quantity);

            _fruits.OnQuantityChanged += q => _fruitsQuantity.OnNext(q);
            _deadSprouts.OnQuantityChanged += q => _deadSproutsQuantity.OnNext(q);
        }

        public HarvestedItem Get(HarvestedItemType type) => type switch
        {
            HarvestedItemType.Fruit => _fruits,
            HarvestedItemType.DeadSprout => _deadSprouts,
            _ => throw new ArgumentException("Invalid type")
        };

        public void Save(HarvestedItem item)
        {
        }
    }
}