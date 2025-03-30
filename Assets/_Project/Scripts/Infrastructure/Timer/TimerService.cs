using System;
using Game.Application.TimerScope;
using UniRx;

namespace Game.Infrastructure.TimerScope
{
    public class TimerService : ITimer
    {
        public void StartTimer(float duration, Action onComplete)
        {
            Observable.Timer(TimeSpan.FromSeconds(duration))
                      .Subscribe(_ => onComplete?.Invoke());
        }
    }
}
