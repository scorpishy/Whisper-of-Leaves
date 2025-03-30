using System;
using Game.Domain.InventoryScope;

namespace Game.Application.InventoryScope
{
    public class SelectedItemInteractor
    {
        private ItemType _selectedItem = ItemType.None;
        
        public event Action<ItemType> OnSelectedItemChanged;

        public ItemType SelectedItem
        {
            get => _selectedItem;
            private set
            {
                if (_selectedItem == value) return;
                _selectedItem = value;
                OnSelectedItemChanged?.Invoke(_selectedItem);
            }
        }

        public void SetSelectedItem(ItemType item)
        {
            SelectedItem = item;
        }
    }
}