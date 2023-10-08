using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private Canvas Main;
    [SerializeField] private Canvas Win;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Win
            Main.gameObject.SetActive(false);
            Win.gameObject.SetActive(true);
        }
    }
}
