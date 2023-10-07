using System.Collections;
using System.Collections.Generic;
//using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class distcalc : MonoBehaviour
{
    [SerializeField]
    private GameObject koraci;
    // Start is called before the first frame update
    void Start()
    {
        setsteps var = koraci.GetComponent<setsteps>();
        double distcalc=var._cursteps*78.75/1000/100;
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = distcalc.ToString("N2")+ " km";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
