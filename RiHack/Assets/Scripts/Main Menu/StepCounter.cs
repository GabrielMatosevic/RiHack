using UnityEngine;
using UnityEngine.UI;
using PedometerU;
using System;
using TMPro;
using UnityEngine.Android;
//using AndroidRuntimePermissionsNamespace;

public class StepCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stepText;
    [SerializeField] private TextMeshProUGUI stepTextLevelSelect;

    private Pedometer pedometer;
    private int currentSteps;

    public void Awake()
    {
        currentSteps = PlayerPrefs.GetInt("Steps", 0);
        stepText.text = currentSteps.ToString();
        stepTextLevelSelect.text = currentSteps.ToString();
        pedometer = new Pedometer(OnStep);
    }

    private void OnStep(int steps, double distance)
    {
        currentSteps += 1;
        stepText.text = currentSteps.ToString();
        stepTextLevelSelect.text = currentSteps.ToString();
    }

    void OnApplicationQuit()
    {
        pedometer.Dispose();
        pedometer = null;
        PlayerPrefs.SetInt("Steps", PlayerPrefs.GetInt("Steps", 0) + currentSteps);
        currentSteps = 0;
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Steps", PlayerPrefs.GetInt("Steps", 0) + currentSteps);
        currentSteps = 0;
    }
}
