using System;
using System.Collections;
using UnityEngine;

class TimerManager : UnitySingleton<TimerManager>
{
    public static IEnumerator Invoke(Action action, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        action();
    }

    public static IEnumerator Invoke<T>(Action<T> action, float delaySeconds, T arg)
    {
        yield return new WaitForSeconds(delaySeconds);
        action(arg);
    }

    public static IEnumerator Invoke<T, U>(Action<T, U> action, float delaySeconds, T arg1, U arg2)
    {
        yield return new WaitForSeconds(delaySeconds);
        action(arg1, arg2);
    }

    private static IEnumerator Invoke(ITimer timer, float delaySeconds) {
        yield return new WaitForSeconds(delaySeconds);
        Debug.LogError("on timer");
        timer.OnTimer();
    }

    public void SetTimer(ITimer timer, float delaySeconds)
    {
        StartCoroutine(Invoke(timer, delaySeconds));
    }
}
