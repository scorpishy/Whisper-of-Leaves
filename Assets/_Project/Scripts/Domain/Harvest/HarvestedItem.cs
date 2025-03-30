using System;
using Game.Domain.CommonScope;

namespace Game.Domain.HarvestScope
{
    public class HarvestedItem : IIdentifiable
    {
        public Guid Id { get; } = Guid.NewGuid();
        public HarvestedItemType ItemType { get; }
        public int Quantity { get; private set; }

        public event Action<int> OnQuantityChanged;

        public HarvestedItem(HarvestedItemType itemType) => ItemType = itemType;

        public void Add(int quantity)
        {
            if (quantity < 0) throw new ArgumentException("Quantity cannot be negative");
            Quantity += quantity;
            OnQuantityChanged?.Invoke(Quantity);
        }
    }
}