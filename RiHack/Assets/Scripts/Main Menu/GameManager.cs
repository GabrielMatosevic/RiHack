using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject setupPanel;
    [SerializeField] private TextMeshProUGUI genderText;
    [SerializeField] private TMP_InputField heightInput;
    [SerializeField] private TMP_InputField weightInput;
    [SerializeField] private TMP_InputField ageInput;
    [SerializeField] private TextMeshProUGUI[] statsTexts;

    public void SetupStats(float height, float weight, float age, int gender)
    {
        // Define average values based on gender
        float heightAverage = (gender == 1) ? 175 : 162;
        float weightAverage = (gender == 1) ? 90 : 77;

        // Calculate BMI for the character and average BMI
        float BMIAverage = weightAverage / (heightAverage * heightAverage);
        float BMI = weight / (height * height);

        // Calculate and set Health
        int Health = ((int)(BMI / BMIAverage * 100));
        Health -= (int)(age * 0.2f);
        Health = Mathf.Abs(Health);
        PlayerPrefs.SetInt("Health", Health);
        statsTexts[0].text = Health.ToString();

        // Calculate and set Strength
        int Strength = ((int)((BMI / BMIAverage * 100) / gender));
        Strength += (int)(age * 0.2f);
        Strength = Mathf.Abs(Strength);
        PlayerPrefs.SetInt("Strength", Strength);
        statsTexts[1].text = Strength.ToString();

        // Calculate and set Speed
        int Speed = (int)((height / heightAverage - weight / weightAverage * 0.3f) * 100 * gender);
        Speed -= (int)(age * 0.2f);
        Speed = Mathf.Abs(Speed);
        PlayerPrefs.SetInt("Speed", Speed);
        statsTexts[2].text = Speed.ToString();

        // Calculate and set Damage
        int Damage = (int)(((height / heightAverage + weight / weightAverage) / 1.8f) * 100 / gender);
        Damage += (int)(age * 0.2f);
        Damage = Mathf.Abs(Damage);
        PlayerPrefs.SetInt("Damage", Damage);
        statsTexts[3].text = Damage.ToString();
    }


    public void SaveHeight(GameObject continueButton)
    {
        string text = heightInput.text;
        if (text != "")
        {
            PlayerPrefs.SetInt("Height", int.Parse(text));
            continueButton.SetActive(true);
        }
        else
        {
            continueButton.SetActive(false);
        }
    }

    public void SaveWeight(GameObject continueButton)
    {
        string text = weightInput.text;
        if (text != "")
        {
            PlayerPrefs.SetInt("Weight", int.Parse(text));
            continueButton.SetActive(true);
        }
        else
        {
            continueButton.SetActive(false);
        }
    }
    public void SaveAge(GameObject continueButton)
    {
        string text = ageInput.text;
        if (text != "")
        {
            PlayerPrefs.SetInt("Age", int.Parse(text));
            continueButton.SetActive(true);

            //End of setup
            PlayerPrefs.SetInt("Setup", 1);
        }
        else
        {
            continueButton.SetActive(false);
        }
    }

    public void ToggleGender()
    {
        int gender = (genderText.text == "Muško") ? 2 : 1;
        genderText.text = (gender == 1) ? "Muško" : "Žensko";
        PlayerPrefs.SetInt("Gender", gender);
    }

    public void ApplyChangedSettings()
    {
        SetupStats(PlayerPrefs.GetInt("Height", 1), PlayerPrefs.GetInt("Weight", 1), PlayerPrefs.GetInt("Age", 1), PlayerPrefs.GetInt("Gender", 1));
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    private void Awake()
    {
        //Check gender, 0 is none, 1 is male, 2 is female
        int gender = PlayerPrefs.GetInt("Gender", 0);
        if (gender != 0)
        {
            genderText.text = (gender == 1) ? "Muško" : "Žensko";
        }

        //Check if setup has not been made
        if (PlayerPrefs.GetInt("Setup", 0) != 1)
        {
            //Load setup
            mainPanel.SetActive(false);
            setupPanel.SetActive(true);
        }
        else
        {
            SetupStats(PlayerPrefs.GetInt("Height", 1), PlayerPrefs.GetInt("Weight", 1), PlayerPrefs.GetInt("Age", 1), PlayerPrefs.GetInt("Gender", 1));
        }
    }
}
