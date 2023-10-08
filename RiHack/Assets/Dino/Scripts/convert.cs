using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;

public class convert : MonoBehaviour
{
    [SerializeField]
    private GameObject amount;
    [SerializeField]
    private GameObject energyamount;
    [SerializeField]
    private GameObject statamount;

    private int energy;
    private int boots;
    private int heart;
    private int musle;
    private int attack;
    // Start is called before the first frame update
    void Start()
    {
        energy = 10000;
        boots = 0;
        heart = 0;
        musle = 0;
        attack = 0;
        energyamount.GetComponent<TextMeshProUGUI>().text = energy.ToString();
        //fetch data
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Convert(){
        Console.WriteLine("convert");
        if(amount.GetComponent<TextMeshProUGUI>().text=="500"&&energy>=500){//boot
            //subtract energy, increment boot and update text
            energy-=500;
            boots += 1;
            statamount.GetComponent<TextMeshProUGUI>().text = boots.ToString();
energyamount.GetComponent<TextMeshProUGUI>().text = energy.ToString();

        }
        else if(amount.GetComponent<TextMeshProUGUI>().text=="1000" &&energy>=1000){//health
        energy-=1000;
            heart += 1;
            statamount.GetComponent<TextMeshProUGUI>().text = heart.ToString();
            energyamount.GetComponent<TextMeshProUGUI>().text = energy.ToString();
        }
        else if(amount.GetComponent<TextMeshProUGUI>().text=="700"&&energy>=700){//strength
        energy-=700;
            musle += 1;
            statamount.GetComponent<TextMeshProUGUI>().text = musle.ToString();
            energyamount.GetComponent<TextMeshProUGUI>().text = energy.ToString();
        }
        else if(amount.GetComponent<TextMeshProUGUI>().text=="800"&&energy>=800){//attack
        energy-=800;
            attack += 1;
            statamount.GetComponent<TextMeshProUGUI>().text = attack.ToString();
            energyamount.GetComponent<TextMeshProUGUI>().text = energy.ToString();
        }
        //save data
    }
}
