using Cysharp.Threading.Tasks;
using System;

public class Timer
{
    private int timerTime;
    private int currentTime;

    private bool timerStoped;
    public bool TimerPaused;

    public event Action<int> TimeChengedEvent;
    public event Action TimeOverEvent;

    public void SetTimer(int time)
    {
        timerTime = time;
    }

    public void StartTimer()
    {
        timerStoped = false;
        TimerPaused = false;
        currentTime = timerTime;
        TimeChengedEvent?.Invoke(currentTime);
        TimerProcess().Forget();
    }
    
    public void StopTimer()
    {
        timerStoped = true;
    }

    private async UniTask TimerProcess()
    {
        while(currentTime > 0)
        {
            if (timerStoped) return;
            if (TimerPaused) continue;

            await UniTask.Delay(1000);

            currentTime--;
            TimeChengedEvent?.Invoke(currentTime);
        }

        TimeOverEvent?.Invoke();
    } 
}
