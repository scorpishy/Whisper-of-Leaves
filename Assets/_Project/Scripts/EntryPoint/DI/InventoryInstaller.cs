using Game.Application.InventoryScope;
using Game.Presentation.InventoryScope;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.EntryPoint.DI
{
    public class InventoryInstaller : MonoBehaviour, IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            builder.Register<InventoryPresenter>(Lifetime.Singleton);
            builder.Register<SelectedItemInteractor>(Lifetime.Singleton);
            builder.RegisterComponentInHierarchy<InventoryUI>();
        }
    }
}
