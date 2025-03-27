using System;
using UniRx;

namespace Game.Infrastructure.Inventory
{
    public interface IInventoryInputService
    {
        IObservable<Unit> OnRightClick { get; }
    }
}
