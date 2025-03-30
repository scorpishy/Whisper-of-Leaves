using Game.Infrastructure.AudioScope;
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
        [SerializeField] private GardenSFXConfig _plantSFXConfig;

        public void Install(IContainerBuilder builder)
        {
            builder.Register<MusicService>(Lifetime.Singleton)
                   .WithParameter(_musicSource);

            builder.Register<SFXService>(Lifetime.Singleton)
                   .WithParameter(_sfxSource);

            builder.Register<GardenSFXHandler>(Lifetime.Singleton)
                   .WithParameter(_plantSFXConfig)
                   .Build();

            builder.RegisterBuildCallback(container => container.Resolve<GardenSFXHandler>());
        }
    }
}
