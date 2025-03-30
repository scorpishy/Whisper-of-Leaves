using VContainer;
using VContainer.Unity;
using UnityEngine;
using UnityEngine.UIElements;
using Game.Application.TimerScope;
using Game.Infrastructure.TimerScope;
using Game.Infrastructure.InputScope;

namespace Game.EntryPoint.DI
{
    public class MainInstaller : LifetimeScope
    {
        [SerializeField] private GardenInstaller _gardenInstaller;
        [SerializeField] private InventoryInstaller _inventoryInstaller;
        [SerializeField] private HarvestInstaller _harvestInstaller;
        [SerializeField] private InputInstaller _inputInstaller;
        [SerializeField] private AudioInstaller _audioInstaller;

        protected override void Configure(IContainerBuilder builder)
        {
            _gardenInstaller.Install(builder);
            _inventoryInstaller.Install(builder);
            _harvestInstaller.Install(builder);
            _audioInstaller.Install(builder);
            _inputInstaller.Install(builder);

            RegisterCommons(builder);
        }

        private void RegisterCommons(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<UIDocument>();
            builder.Register<ITimer, TimerService>(Lifetime.Singleton);
        }
    }
}
