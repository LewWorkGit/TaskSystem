using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TimerTaskView : MonoBehaviour
{
    [Inject] TimerTaskModel timerTaskModel;

    [SerializeField] private Slider progressSlider;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] GameObject completeTaskImage;
    [SerializeField] AudioSource complateSound;
    [SerializeField] Image sliderComplateColor;


    private void OnEnable()
    {
        timerTaskModel.OnOneSecond += TimerViev;
        timerTaskModel.OnTimeOver += ComplateTask;
    }
    private void OnDisable()
    {
        timerTaskModel.OnOneSecond -= TimerViev;
        timerTaskModel.OnTimeOver -= ComplateTask;
    }


    private void TimerViev(int minutes, int seconds)//вызуализирует таймер
    {
        progressSlider.value = 120 - timerTaskModel.GetTotalTime();
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void ComplateTask()//визуализирует завершение задания
    {
        completeTaskImage.SetActive(true);
        sliderComplateColor.color = Color.green;
        timerText.text = "00:00";
        timerText.color = Color.black;
        complateSound.Play();
    }
}
