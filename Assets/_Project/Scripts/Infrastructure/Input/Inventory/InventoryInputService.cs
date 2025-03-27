using System;
using UniRx;
using UnityEngine.InputSystem;

namespace Game.Infrastructure.Input
{
    public class InventoryInputService : IInventoryInputService, IDisposable
    {
        private readonly SystemInputActions _input;
        private readonly Action<InputAction.CallbackContext> _rightClickHandler;
        private readonly Subject<Unit> _onRightClick = new();

        public IObservable<Unit> OnRightClick => _onRightClick;

        public InventoryInputService(SystemInputActions input)
        {
            _input = input;

            _rightClickHandler = ctx => _onRightClick.OnNext(Unit.Default);
            _input.UI.RightClick.performed += _rightClickHandler;
            _input.UI.Enable();
        }

        public void Dispose()
        {
            _input.UI.RightClick.performed -= _rightClickHandler;
            _input.UI.Disable();
            _onRightClick.Dispose();
        }
    }
}
