using System;
using Game.Domain.Inventory;
using UniRx;

namespace Game.Infrastructure.Inventory
{
    public class SelectedItemService : ISelectedItemService
    {
        private readonly ReactiveProperty<ItemType> _selectedItem = new(ItemType.None);

        public ItemType SelectedItem => _selectedItem.Value;
        public IObservable<ItemType> SelectedItemObservable => _selectedItem.Skip(1);

        public void SetSelectedItem(ItemType item)
        {
            _selectedItem.Value = item;
        }
    }
}
