using System;

namespace Game.Domain.Harvest
{
    public class HarvestedItem : IHarvestedItem
    {
        public Guid Id { get; } = Guid.NewGuid();

        public HarvestedItemType ItemType { get; }
        public int Quantity { get; private set; }

        public event Action<int> OnQuantityChanged;

        public HarvestedItem(HarvestedItemType itemType, int quantity = 0)
        {
            ItemType = itemType;
            Quantity = quantity;
        }

        public void Add(int count)
        {
            Quantity += count;
            OnQuantityChanged?.Invoke(Quantity);
        }
    }
}