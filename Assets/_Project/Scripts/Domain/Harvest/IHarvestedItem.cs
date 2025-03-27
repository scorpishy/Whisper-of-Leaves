using System;

namespace Game.Domain.Harvest
{
    public interface IHarvestedItem
    {
        HarvestedItemType ItemType { get; }
        int Quantity { get; }
        event Action<int> OnQuantityChanged;

        void Add(int count);
    }
}