using UnityEngine;
using UnityEngine.UIElements;
using VContainer;
using UniRx;
using Game.Infrastructure.Harvest;
using Game.Domain.Harvest;

namespace Game.Presentation.Harvest
{
    public class HarvestPanelUI : MonoBehaviour
    {
        private readonly CompositeDisposable _disposables = new();

        private UIDocument _uiDocument;
        private IHarvestService _harvestService;

        private Label _fruitLabel;
        private Label _deadSproutLabel;

        [Inject]
        public void Construct(UIDocument uiDocument, IHarvestService harvestService)
        {
            _uiDocument = uiDocument;
            _harvestService = harvestService;
        }

        private void Awake()
        {
            VisualElement root = _uiDocument.rootVisualElement;
            _fruitLabel = root.Q<Label>("fruit-label");
            _deadSproutLabel = root.Q<Label>("dead-sprout-label");

            SubscribeToHarvestChanges();
        }

        private void SubscribeToHarvestChanges()
        {
            IHarvestedItem fruitItem = _harvestService.CollectedFruits;
            IHarvestedItem deadSproutItem = _harvestService.DeadSprouts;

            Observable.FromEvent<int>(
                h => fruitItem.OnQuantityChanged += h,
                h => fruitItem.OnQuantityChanged -= h
            )
            .Subscribe(quantity => _fruitLabel.text = $"Fruits: {quantity}")
            .AddTo(_disposables);

            Observable.FromEvent<int>(
                h => deadSproutItem.OnQuantityChanged += h,
                h => deadSproutItem.OnQuantityChanged -= h
            )
            .Subscribe(quantity => _deadSproutLabel.text = $"Dead Sprouts: {quantity}")
            .AddTo(_disposables);
        }

        private void OnDestroy() => _disposables.Dispose();
    }
}
