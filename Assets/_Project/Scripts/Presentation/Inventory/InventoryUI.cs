using Game.Domain.Inventory;
using UnityEngine;
using UnityEngine.UIElements;
using UniRx;
using VContainer;
using System.Collections.Generic;
using Game.Infrastructure.Inventory;

namespace Game.Presentation.Inventory
{
    public class InventoryUI : MonoBehaviour
    {
        private UIDocument _uiDocument;
        private IInventoryPresenter _inventoryPresenter;
        private readonly Dictionary<ItemType, Button> _buttons = new();
        private readonly CompositeDisposable _disposables = new();

        [Inject]
        public void Construct(UIDocument uiDocument, IInventoryPresenter inventoryPresenter)
        {
            _uiDocument = uiDocument;
            _inventoryPresenter = inventoryPresenter;
        }

        private void Awake()
        {
            VisualElement root = _uiDocument.rootVisualElement;

            _buttons[ItemType.Seed] = root.Q<Button>("seed-button");
            _buttons[ItemType.WateringCan] = root.Q<Button>("watering-can-button");
            _buttons[ItemType.Shovel] = root.Q<Button>("shovel-button");

            SubscribeToUI();
        }

        private void SubscribeToUI()
        {
            foreach ((ItemType itemType, Button button) in _buttons)
            {
                Observable.FromEvent(
                    h => button.clicked += h,
                    h => button.clicked -= h
                )
                .Subscribe(_ => _inventoryPresenter.OnItemClicked(itemType))
                .AddTo(_disposables);
            }

            _inventoryPresenter.SelectedItemObservable
                .Subscribe(UpdateSelection)
                .AddTo(_disposables);
        }

        private void UpdateSelection(ItemType selectedItem)
        {
            foreach (Button button in _buttons.Values)
            {
                button.RemoveFromClassList("inventory__item--selected");
            }

            if (_buttons.TryGetValue(selectedItem, out Button selectedButton))
            {
                selectedButton.AddToClassList("inventory__item--selected");
            }
        }

        private void OnDestroy() => _disposables.Dispose();
    }
}
