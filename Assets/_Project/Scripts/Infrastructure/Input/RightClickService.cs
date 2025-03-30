using UniRx;
using UnityEngine.InputSystem;
using Game.Application.InputScope;
using System;

namespace Game.Infrastructure.InputScope
{
    public class RightClickService : IRightClick, IDisposable
    {
        private readonly SystemInputActions _input;
        private readonly CompositeDisposable _disposables = new();

        public event Action OnRightClick;

        public RightClickService(SystemInputActions input)
        {
            _input = input;

            Observable.FromEvent<InputAction.CallbackContext>(
                h => _input.UI.RightClick.performed += h,
                h => _input.UI.RightClick.performed -= h
            ).Subscribe(_ => OnRightClick?.Invoke())
             .AddTo(_disposables);

            _input.UI.Enable();
        }

        public void Dispose()
        {
            _input.UI.Disable();
            _disposables.Dispose();
        }
    }
}