using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text loadingProgressText;
    [SerializeField] private Slider loadingProgressSlider;
    [SerializeField] private int loadingTime;
    [SerializeField] private float timeStep;
    private float currentTime;

    public event Action LoadingIsOver;

    private void Start()
    {
        StartLoading();
    }

    public void StartLoading()
    {
        currentTime = 0;
        Loading().Forget();
    }

    private async UniTask Loading()
    {
        while(currentTime < loadingTime)
        {
            loadingProgressSlider.value = currentTime / loadingTime;
            loadingProgressText.text = (int)(loadingProgressSlider.value * 100) + "%";

            await UniTask.Delay((int)(timeStep * 1000));

            currentTime += timeStep;
        }

        LoadingIsOver?.Invoke();
        gameObject.SetActive(false);
    }
}
