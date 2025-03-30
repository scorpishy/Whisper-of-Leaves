using System;
using Game.Domain.HarvestScope;
using UniRx;
using VContainer.Unity;

namespace Game.Presentation.HarvestScope
{
    public class HarvestPresenter : IDisposable, IStartable
    {
        private readonly IHarvestRepository _repository;
        private readonly HarvestPanelUI _ui;
        private readonly CompositeDisposable _disposables = new();

        public HarvestPresenter(IHarvestRepository repository, HarvestPanelUI ui)
        {
            _repository = repository;
            _ui = ui;
        }

        public void Start()
        {
            _repository.FruitsQuantity
                .Subscribe(q => _ui.UpdateFruitsLabel(q))
                .AddTo(_disposables);

            _repository.DeadSproutsQuantity
                .Subscribe(q => _ui.UpdateDeadSproutsLabel(q))
                .AddTo(_disposables);
        }

        public void Dispose() => _disposables.Dispose();
    }
}