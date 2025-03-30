using Game.Application.InputScope;
using Game.Infrastructure.InputScope;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.EntryPoint.DI
{
    public class InputInstaller : MonoBehaviour, IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            builder.Register<SystemInputActions>(Lifetime.Singleton);
            builder.Register<IRightClick, RightClickService>(Lifetime.Singleton);
        }
    }
}
