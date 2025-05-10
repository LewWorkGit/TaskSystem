using UnityEngine;
using Zenject;


public class TaskController : MonoBehaviour
{
    [Inject] private SphereController sphereController;
    
    [SerializeField] private GameObject task_1;
    [SerializeField] private GameObject task_2;
    [SerializeField] private GameObject task_3;


    private ITask timerTask;


    private void OnEnable()
    {
        timerTask = task_1.GetComponent<ITask>();
        sphereController.OnAnySphereDestroy += task_2.GetComponent<ITask>().TaskStep;
        sphereController.OnRedSphereDestroy += task_3.GetComponent<ITask>().TaskStep;
    }

    private void OnDisable()
    {
        if (sphereController != null)
        {
            sphereController.OnAnySphereDestroy -= task_2.GetComponent<ITask>().TaskStep;
            sphereController.OnRedSphereDestroy -= task_3.GetComponent<ITask>().TaskStep;
        }
       
    }

    private void Update()
    {
        timerTask.TaskStep();
    }
}
