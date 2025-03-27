using System;
using Game.Application.Timer;
using UniRx;

namespace Game.Infrastructure.Timer
{
    public class TimerService : ITimerService
    {
        public void StartTimer(float duration, Action onComplete)
        {
            Observable.Timer(TimeSpan.FromSeconds(duration))
                      .Subscribe(_ => onComplete?.Invoke());
        }
    }
}
