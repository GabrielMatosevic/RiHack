using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class imgch : MonoBehaviour
{
    [SerializeField]
    private GameObject icon;
    [SerializeField]
    private GameObject cost;
    //public Sprite soundOn;
    [SerializeField]
    private Sprite image;
    [SerializeField]
    private GameObject amount;
    public void ChangeSprite()
    {
        // getting Image component of soundButton and changing it
        cost.GetComponent<TextMeshProUGUI>().text = "500";
        icon.GetComponent<Image>().sprite = image;
        icon.transform.localScale = new Vector3(2,2,2);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
