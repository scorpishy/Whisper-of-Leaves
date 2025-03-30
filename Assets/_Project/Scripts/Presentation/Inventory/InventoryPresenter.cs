using UniRx;
using Game.Application.InventoryScope;
using Game.Application.InputScope;
using Game.Domain.InventoryScope;
using System;

namespace Game.Presentation.InventoryScope
{
    public class InventoryPresenter : IDisposable
    {
        private readonly SelectedItemInteractor _selectedItemInteractor;
        private readonly IRightClick _inputService;
        private readonly CompositeDisposable _disposables = new();
        private readonly IObservable<ItemType> _selectedItemChanged;

        public IObservable<ItemType> SelectedItemChanged => _selectedItemChanged;

        public InventoryPresenter(SelectedItemInteractor selectedItemInteractor, IRightClick inputService)
        {
            _selectedItemInteractor = selectedItemInteractor;
            _inputService = inputService;

            _selectedItemChanged = Observable.FromEvent<Action<ItemType>, ItemType>(
                handler => handler.Invoke,
                h => _selectedItemInteractor.OnSelectedItemChanged += h,
                h => _selectedItemInteractor.OnSelectedItemChanged -= h
            );

            SubscribeToInput();
        }

        private void SubscribeToInput()
        {
            Observable.FromEvent(
                h => _inputService.OnRightClick += h,
                h => _inputService.OnRightClick -= h
            ).Subscribe(_ => HandleRightClick())
             .AddTo(_disposables);
        }

        private void HandleRightClick()
        {
            _selectedItemInteractor.SetSelectedItem(ItemType.None);
        }

        public void OnItemClicked(ItemType item)
        {
            var currentItem = _selectedItemInteractor.SelectedItem;
            _selectedItemInteractor.SetSelectedItem(currentItem == item ? ItemType.None : item);
        }

        public void Dispose() => _disposables.Dispose();
    }
}