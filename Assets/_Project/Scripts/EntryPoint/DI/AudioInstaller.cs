using Game.Infrastructure.Audio;
using Game.Infrastructure.Configs;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.EntryPoint.DI
{
    public class AudioInstaller : MonoBehaviour, IInstaller
    {
        [Header("Audio Sources")]
        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource _sfxSource;

        [Header("Audio Configs")]
        [SerializeField] private PlantSFXConfig _plantSFXConfig;

        public void Install(IContainerBuilder builder)
        {
            builder.Register<IMusicService, MusicService>(Lifetime.Singleton)
                   .WithParameter(_musicSource);

            builder.Register<ISFXService, SFXService>(Lifetime.Singleton)
                   .WithParameter(_sfxSource);

            builder.Register<PlantSFXService>(Lifetime.Singleton)
                   .WithParameter(_plantSFXConfig)
                   .Build();

            builder.RegisterBuildCallback(container => container.Resolve<PlantSFXService>());
        }
    }
}
