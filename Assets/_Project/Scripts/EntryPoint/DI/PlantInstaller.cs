using Game.Application.Plant;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.EntryPoint.DI
{
    public class PlantInstaller : MonoBehaviour, IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            builder.Register<IPlantSeedInteractor, PlantSeedInteractor>(Lifetime.Singleton);
            builder.Register<IWaterPlantInteractor, WaterPlantInterator>(Lifetime.Singleton);
            builder.Register<IRemovePlantInteractor, RemovePlantInterator>(Lifetime.Singleton);
            builder.Register<IGrowPlantInteractor, GrowPlantInteractor>(Lifetime.Singleton);
        }
    }
}
