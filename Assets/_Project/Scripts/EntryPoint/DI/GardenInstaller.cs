using Game.Application.GardenScope;
using Game.Domain.GardenScope;
using Game.Presentation.GardenScope;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.EntryPoint.DI
{
    public class GardenInstaller : MonoBehaviour, IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            builder.Register<Garden>(Lifetime.Singleton);
            builder.Register<GardenCellPresenter>(Lifetime.Singleton);
            builder.RegisterFactory(() => new GardenCell(() => new Plant()));
            builder.RegisterComponentInHierarchy<GardenView>();
            builder.Register<PlantRemovedHandler>(Lifetime.Singleton);
            builder.RegisterBuildCallback(container => container.Resolve<PlantRemovedHandler>());

            RegisterPlantInteractors(builder);
        }

        private void RegisterPlantInteractors(IContainerBuilder builder)
        {
            builder.Register<PlantSeedInteractor>(Lifetime.Singleton);
            builder.Register<WaterPlantInteractor>(Lifetime.Singleton);
            builder.Register<RemovePlantInteractor>(Lifetime.Singleton);
            builder.Register<GrowPlantInteractor>(Lifetime.Singleton);
        }
    }
}
