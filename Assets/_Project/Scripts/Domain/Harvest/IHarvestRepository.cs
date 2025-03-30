using System;

namespace Game.Domain.HarvestScope
{
    public interface IHarvestRepository
    {
        IObservable<int> FruitsQuantity { get; }
        IObservable<int> DeadSproutsQuantity { get; }

        HarvestedItem Get(HarvestedItemType type);
        void Save(HarvestedItem item);
    }
}