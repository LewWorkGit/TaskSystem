using System;
using UnityEngine;

public class RedSphereTaskModel : MonoBehaviour, ITask
{
    private int progressCount;

    private int targetTaskValue = 10;

    public event Action<int> OnStepTask;
    public event Action OnComplateTask;


    void ITask.TaskStep()//добовляет прогресс в выполнении задания
    {
        if (progressCount != targetTaskValue)
        {

            progressCount++;

            OnStepTask?.Invoke(progressCount);

            if (progressCount == targetTaskValue)
            {
                OnComplateTask?.Invoke();
            }
        }
    }


}
