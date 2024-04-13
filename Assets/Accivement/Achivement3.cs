using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achivement3 : MonoBehaviour
{
    public GameObject footprint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPrefs.SetString("Achivement3", "Check");
            footprint.SetActive(true);
        }
    }
}
