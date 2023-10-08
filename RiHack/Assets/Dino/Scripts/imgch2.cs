using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class imgch2 : MonoBehaviour
{
    [SerializeField]
    private GameObject icon;
    [SerializeField]
    private GameObject cost;
    //public Sprite soundOn;
    [SerializeField]
    private Sprite image;
    public void ChangeSprite()
    {
        // getting Image component of soundButton and changing it
        cost.GetComponent<TextMeshProUGUI>().text = "700";
        icon.GetComponent<Image>().sprite = image;
        icon.transform.localScale = new Vector3(3, 3,3);
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
