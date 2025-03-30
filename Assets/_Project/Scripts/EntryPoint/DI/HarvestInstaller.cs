using Game.Application.HarvestScope;
using Game.Domain.HarvestScope;
using Game.Infrastructure.HarvestScope;
using Game.Presentation.HarvestScope;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.EntryPoint.DI
{
    public class HarvestInstaller : MonoBehaviour, IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            builder.RegisterFactory<HarvestedItemType, HarvestedItem>((type) => new HarvestedItem(type));
            builder.Register<HarvestInteractor>(Lifetime.Singleton);
            builder.Register<IHarvestRepository, HarvestRepository>(Lifetime.Singleton);
            builder.RegisterEntryPoint<HarvestPresenter>(Lifetime.Singleton);
            builder.RegisterComponentInHierarchy<HarvestPanelUI>();
        }
    }
}
