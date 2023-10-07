using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject setupPanel;
    [SerializeField] private TextMeshProUGUI genderText;
    [SerializeField] private TMP_InputField heightInput;
    [SerializeField] private TMP_InputField weightInput;
    [SerializeField] private TMP_InputField ageInput;

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
    }
}
