using System;
using Game.Domain.Inventory;

namespace Game.Infrastructure.Inventory
{
    public interface IInventoryPresenter
    {
        IObservable<ItemType> SelectedItemObservable { get; }
        void OnItemClicked(ItemType item);
    }
}
