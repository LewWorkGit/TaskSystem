using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimerTaskModel : MonoBehaviour, ITask
{

    private float totalTime = 120;
    private bool isOverTime;

    public event Action<int, int> OnOneSecond;
    public event Action OnTimeOver;

    void ITask.TaskStep()//отнимает 1 секунду на таймере
    {
        if (totalTime > 0)
        {
            totalTime -= Time.deltaTime;
            OneSecond();
        }
        else if (!isOverTime)
        {
            OnTimeOver.Invoke();
            isOverTime = true;
        }
    }

    void OneSecond()//рассчитывает минуты и секунды из общего значения таймера
    {
        int minutes = Mathf.FloorToInt(totalTime / 60);
        int seconds = Mathf.FloorToInt(totalTime % 60);


        OnOneSecond.Invoke(minutes, seconds);
    }

    public float GetTotalTime()
    {
        return totalTime;
    }

  
}
