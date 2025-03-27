using VContainer;
using VContainer.Unity;
using UnityEngine;
using UnityEngine.UIElements;
using Game.Application.Timer;
using Game.Infrastructure.Timer;

namespace Game.EntryPoint.DI
{
    public class MainInstaller : LifetimeScope
    {
        [SerializeField] private GardenInstaller _gardenInstaller;
        [SerializeField] private InventoryInstaller _inventoryInstaller;
        [SerializeField] private HarvestInstaller _harvestInstaller;
        [SerializeField] private PlantInstaller _plantInstaller;
        [SerializeField] private AudioInstaller _audioInstaller;

        protected override void Configure(IContainerBuilder builder)
        {
            _gardenInstaller.Install(builder);
            _inventoryInstaller.Install(builder);
            _harvestInstaller.Install(builder);
            _plantInstaller.Install(builder);
            _audioInstaller.Install(builder);

            RegisterCommons(builder);
        }

        private void RegisterCommons(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<UIDocument>();
            builder.Register<SystemInputActions>(Lifetime.Singleton);
            builder.Register<ITimerService, TimerService>(Lifetime.Singleton);
        }
    }
}
