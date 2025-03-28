using System;
using Game.Domain.Common;

namespace Game.Domain.Harvest
{
    public interface IHarvestedItem : IIdentifiable
    {
        HarvestedItemType ItemType { get; }
        int Quantity { get; }
        event Action<int> OnQuantityChanged;

        void Add(int count);
    }
}