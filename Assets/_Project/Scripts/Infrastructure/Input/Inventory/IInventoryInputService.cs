using System;
using UniRx;

namespace Game.Infrastructure.Input
{
    public interface IInventoryInputService
    {
        IObservable<Unit> OnRightClick { get; }
    }
}
