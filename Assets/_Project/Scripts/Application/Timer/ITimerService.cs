using System;

namespace Game.Application.Timer
{
    public interface ITimerService
    {
        void StartTimer(float duration, Action onComplete);
    }
}
