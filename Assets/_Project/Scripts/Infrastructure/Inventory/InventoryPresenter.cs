using Game.Domain.Inventory;
using UniRx;
using System;
using VContainer;

namespace Game.Infrastructure.Inventory
{
    public class InventoryPresenter : IInventoryPresenter, IDisposable
    {
        private readonly ISelectedItemService _selectedItemService;
        private readonly IInventoryInputService _inputService;
        private readonly CompositeDisposable _disposables = new();
        private readonly ReactiveProperty<ItemType> _selectedItem = new(ItemType.None);

        public IObservable<ItemType> SelectedItemObservable => _selectedItem;

        [Inject]
        public InventoryPresenter(ISelectedItemService selectedItemService, IInventoryInputService inputService)
        {
            _selectedItemService = selectedItemService;
            _inputService = inputService;

            _selectedItemService.SelectedItemObservable
                .Subscribe(item => _selectedItem.Value = item)
                .AddTo(_disposables);

            _inputService.OnRightClick
                .Subscribe(_ => _selectedItemService.SetSelectedItem(ItemType.None))
                .AddTo(_disposables);
        }

        public void OnItemClicked(ItemType item)
        {
            _selectedItemService.SetSelectedItem(_selectedItem.Value == item ? ItemType.None : item);
        }

        public void Dispose() => _disposables.Dispose();
    }
}
