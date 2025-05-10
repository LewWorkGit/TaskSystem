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

    void ITask.TaskStep()//�������� 1 ������� �� �������
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

    void OneSecond()//������������ ������ � ������� �� ������ �������� �������
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
