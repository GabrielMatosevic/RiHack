using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI energyText;

    private int Energy;

    private void Start()
    {
        Energy = PlayerPrefs.GetInt("Steps", 0);
        energyText.text = Energy.ToString();
    }

    public void ChooseLevel(int cost)
    {
        int levelIndex = (cost == 2500)?1:(cost == 5000)?2:3;
        if (cost <= Energy)
        {
            Energy -= cost;
            PlayerPrefs.SetInt("Steps", Energy);
            //Start Level
            SceneManager.LoadScene(levelIndex, LoadSceneMode.Single);
        }
    }

    public void BackButton()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
