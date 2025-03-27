using Game.Infrastructure.Input;
using Game.Infrastructure.Inventory;
using Game.Presentation.Inventory;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.EntryPoint.DI
{
    public class InventoryInstaller : MonoBehaviour, IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            builder.Register<ISelectedItemService, SelectedItemService>(Lifetime.Singleton);
            builder.Register<IInventoryInputService, InventoryInputService>(Lifetime.Singleton);
            builder.Register<IInventoryPresenter, InventoryPresenter>(Lifetime.Singleton);
            builder.RegisterComponentInHierarchy<InventoryUI>();
        }
    }
}
