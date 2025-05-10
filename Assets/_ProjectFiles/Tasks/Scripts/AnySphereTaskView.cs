using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class AnySphereTaskView : MonoBehaviour
{
    [Inject] AnySphereTaskModel anySphereTaskModel;

    [SerializeField] private Slider progressSlider;
    [SerializeField] private TextMeshProUGUI progressText;
    [SerializeField] GameObject completeTaskImage;
    [SerializeField] AudioSource complateSound;
    [SerializeField] Image sliderComplateColor;




    private void OnEnable()
    {
        anySphereTaskModel.OnStepTask += StepProgress;
        anySphereTaskModel.OnComplateTask += ComplateTask;
    }

    private void OnDisable()
    {
        anySphereTaskModel.OnStepTask -= StepProgress;
        anySphereTaskModel.OnComplateTask -= ComplateTask;
    }

    private void StepProgress(int progressValue)//визуализирует прогресс задания
    {
        progressSlider.value = progressValue;
        progressText.text = progressValue.ToString() + " / 15";
    }

    private void ComplateTask()//визуализирует выполнение задания
    {
        completeTaskImage.SetActive(true);
        sliderComplateColor.color = Color.green;
        progressText.color = Color.black;
        complateSound.Play();
    }
}
