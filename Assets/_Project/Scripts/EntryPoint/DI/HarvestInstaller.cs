using Game.Domain.Harvest;
using Game.Infrastructure.Harvest;
using Game.Presentation.Harvest;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.EntryPoint.DI
{
    public class HarvestInstaller : MonoBehaviour, IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            builder.Register<IHarvestService, HarvestService>(Lifetime.Singleton);
            builder.RegisterFactory<HarvestedItemType, IHarvestedItem>((type) => new HarvestedItem(type));
            builder.RegisterComponentInHierarchy<HarvestPanelUI>();
        }
    }
}
