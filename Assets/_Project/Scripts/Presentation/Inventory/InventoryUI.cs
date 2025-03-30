using UnityEngine;
using UnityEngine.UIElements;
using VContainer;
using UniRx;
using System.Collections.Generic;
using Game.Domain.InventoryScope;

namespace Game.Presentation.InventoryScope
{
    public class InventoryUI : MonoBehaviour
    {
        private UIDocument _uiDocument;
        private InventoryPresenter _presenter;
        private readonly Dictionary<ItemType, Button> _buttons = new();
        private readonly CompositeDisposable _disposables = new();

        [Inject]
        public void Construct(UIDocument uiDocument, InventoryPresenter presenter)
        {
            _uiDocument = uiDocument;
            _presenter = presenter;
        }

        private void Awake()
        {
            VisualElement root = _uiDocument.rootVisualElement;

            _buttons[ItemType.Seed] = root.Q<Button>("seed-button");
            _buttons[ItemType.WateringCan] = root.Q<Button>("watering-can-button");
            _buttons[ItemType.Shovel] = root.Q<Button>("shovel-button");

            SubscribeToUI();
            SubscribeToPresenter();
        }

        private void SubscribeToUI()
        {
            foreach (var pair in _buttons)
            {
                var itemType = pair.Key;
                var button = pair.Value;

                Observable.FromEvent(
                    handler => button.clicked += handler,
                    handler => button.clicked -= handler
                )
                .Subscribe(_ => _presenter.OnItemClicked(itemType))
                .AddTo(_disposables);
            }
        }

        private void SubscribeToPresenter()
        {
            _presenter.SelectedItemChanged
                .Subscribe(UpdateSelection)
                .AddTo(_disposables);
        }

        private void UpdateSelection(ItemType selectedItem)
        {
            foreach (var button in _buttons.Values)
            {
                button.RemoveFromClassList("inventory__item--selected");
            }

            if (_buttons.TryGetValue(selectedItem, out var selectedButton))
            {
                selectedButton.AddToClassList("inventory__item--selected");
            }
        }

        private void OnDestroy()
        {
            _disposables.Dispose();
        }
    }
}