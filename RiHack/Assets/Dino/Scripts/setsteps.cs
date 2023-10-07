using UnityEngine;
using UnityEngine.UI;
using PedometerU;

public class setsteps : MonoBehaviour
{
    
    public Text stepText;
    private Pedometer pedometer;
     public int _cursteps;
    public int _goal;
    [SerializeField]
    private GameObject skripta;

    public void Start()
    {
        pedometer = new Pedometer(OnStep);
    	  HealthSystem hs = skripta.GetComponent<HealthSystem>();
    	  hs.maxHitPoint=_goal;
    	  hs.hitPoint=_cursteps;
    }
    private void OnStep (int steps, double distance) {
        // Display the step count
        stepText.text = steps.ToString();
        _cursteps += 1;
        HealthSystem hs = skripta.GetComponent<HealthSystem>();
        hs.hitPoint=_cursteps;
    }
}