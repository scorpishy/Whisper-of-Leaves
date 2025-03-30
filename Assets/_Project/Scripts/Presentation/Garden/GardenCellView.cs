using System;
using Game.Domain.GardenScope;
using UniRx;
using UnityEngine;

namespace Game.Presentation.GardenScope
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

        private Guid _cellId;
        private Garden _garden;
        private GardenCellPresenter _gardenCellPresenter;
        private readonly CompositeDisposable _disposables = new();

        public void Initialize(Guid cellId, Garden garden, GardenCellPresenter presenter)
        {
            _cellId = cellId;
            _garden = garden;
            _gardenCellPresenter = presenter;

            SubscribeToGardenStateChanged();
            UpdateVisual(_garden.GetCellState(_cellId));
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
            _gardenCellPresenter.ExecuteCellAction(_cellId);
        }

        private void SubscribeToGardenStateChanged()
        {
            Observable.FromEvent<Action<Guid, PlantState>, PlantState>(
                h => (id, state) => { if (id == _cellId) h(state); },
                h => _garden.OnCellStateChanged += h,
                h => _garden.OnCellStateChanged -= h
            ).Subscribe(UpdateVisual)
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
