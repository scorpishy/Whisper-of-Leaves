using System;
using Game.Domain.GardenScope;
using UniRx;

namespace Game.Infrastructure.AudioScope
{
    public class GardenSFXHandler : IDisposable
    {
        private readonly SFXService _sfxService;
        private readonly GardenSFXConfig _sfxConfig;
        private readonly CompositeDisposable _disposables = new();

        public GardenSFXHandler(SFXService sfxService, Garden garden, GardenSFXConfig sfxConfig)
        {
            _sfxService = sfxService;
            _sfxConfig = sfxConfig;

            foreach (GardenCell cell in garden.Cells.Values)
            {
                ObserveCellStateChanges(cell);
            }
        }

        private void ObserveCellStateChanges(GardenCell cell)
        {
            Observable.FromEvent<PlantState>(
                h => cell.OnStateChanged += h,
                h => cell.OnStateChanged -= h
            ).Subscribe(HandleStateChange)
             .AddTo(_disposables);
        }

        private void HandleStateChange(PlantState newState)
        {
            switch (newState)
            {
                case PlantState.Fruit:
                    _sfxService.PlayOneShot(_sfxConfig.FruitGrownClip);
                    break;
                case PlantState.DeadSprout:
                    _sfxService.PlayOneShot(_sfxConfig.PlantWitheredClip);
                    break;
            }
        }

        public void Dispose() => _disposables.Dispose();
    }
}