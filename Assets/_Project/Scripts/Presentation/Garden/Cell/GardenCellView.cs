using Game.Domain.Garden;
using Game.Domain.Plant;
using Game.Infrastructure.Garden;
using UniRx;
using UnityEngine;
using VContainer;

namespace Game.Presentation.Garden
{
    public class GardenCellView : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private SpriteRenderer _spriteRenderer;

        [Header("Sprites")]
        [SerializeField] private Sprite _seedSprite;
        [SerializeField] private Sprite _sproutSprite;
        [SerializeField] private Sprite _deadSproutSprite;
        [SerializeField] private Sprite _fruitSprite;

        private IGardenCell _cell;
        private IGardenCellPresenter _gardenCellPresenter;
        private readonly CompositeDisposable _disposables = new();

        public void Initialize(IGardenCell cell, IGardenCellPresenter presenter)
        {
            _cell = cell;
            _gardenCellPresenter = presenter;

            SubscribeToCellStateChanged();
            UpdateVisual(_cell.IsEmpty ? PlantState.None : _cell.Plant.State);
        }

        private void Awake()
        {
            if (GetComponent<Collider2D>() == null)
                gameObject.AddComponent<BoxCollider2D>();

            if (_spriteRenderer == null)
                Debug.LogError($"{nameof(SpriteRenderer)} is missing on {gameObject.name}!");
        }

        private void OnMouseDown()
        {
            _gardenCellPresenter.ExecuteCellAction(_cell);
        }

        private void SubscribeToCellStateChanged()
        {
            Observable.FromEvent<PlantState>(
                h => _cell.OnStateChanged += h,
                h => _cell.OnStateChanged -= h
            )
            .Subscribe(UpdateVisual)
            .AddTo(_disposables);
        }

        private void UpdateVisual(PlantState state)
        {
            _spriteRenderer.sprite = state switch
            {
                PlantState.None => null,
                PlantState.Seed => _seedSprite,
                PlantState.Sprout => _sproutSprite,
                PlantState.DeadSprout => _deadSproutSprite,
                PlantState.Fruit => _fruitSprite,
                _ => null
            };
        }

        private void OnDestroy() => _disposables.Dispose();
    }
}
