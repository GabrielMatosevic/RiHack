using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class calcconv : MonoBehaviour
{[SerializeField]
    private GameObject soundButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateconv(string name){
        Console.WriteLine(name);
        if (soundButton.GetComponent<Image>().sprite.name=="Boots.png") { 

        };
    }
}
