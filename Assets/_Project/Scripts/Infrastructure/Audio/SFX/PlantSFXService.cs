using System;
using Game.Domain.Garden;
using Game.Domain.Plant;
using Game.EntryPoint.Configs;
using UniRx;
using UnityEngine;

namespace Game.Infrastructure.Audio
{
    public class PlantSFXService : IDisposable
    {
        private readonly ISFXService _sfxService;
        private readonly PlantSFXConfig _sfxConfig;
        private readonly CompositeDisposable _disposables = new();

        public PlantSFXService(ISFXService sfxService, IGarden garden, PlantSFXConfig sfxConfig)
        {
            _sfxService = sfxService;
            _sfxConfig = sfxConfig;

            foreach (IGardenCell cell in garden.Cells)
            {
                ObserveCellStateChanges(cell);
            }
        }

        private void ObserveCellStateChanges(IGardenCell cell)
        {
            Observable.FromEvent<PlantState>(
                h => cell.OnStateChanged += h,
                h => cell.OnStateChanged -= h
            )
            .Subscribe(HandleStateChange)
            .AddTo(_disposables);
        }

        private void HandleStateChange(PlantState newState)
        {
            switch (newState)
            {
                case PlantState.Fruit:
                    PlaySound(_sfxConfig.FruitGrownClip);
                    break;
                case PlantState.DeadSprout:
                    PlaySound(_sfxConfig.PlantWitheredClip);
                    break;
            }
        }

        private void PlaySound(AudioClip clip)
        {
            if (clip == null) return;
            _sfxService.PlayOneShot(clip);
        }

        public void Dispose() => _disposables.Dispose();
    }
}