using Game.Domain.Inventory;
using System;

namespace Game.Infrastructure.Inventory
{
    public interface ISelectedItemService
    {
        ItemType SelectedItem { get; }
        IObservable<ItemType> SelectedItemObservable { get; }

        void SetSelectedItem(ItemType item);
    }
}
