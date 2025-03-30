using System;

namespace Game.Application.TimerScope
{
    public interface ITimer
    {
        void StartTimer(float duration, Action onComplete);
    }
}
