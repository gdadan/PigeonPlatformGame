using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Lobby : MonoBehaviour
{
     public Image storagePopUp;
     public Image museumPopUp;
     public Image parkingAreaPopUp;
     public Image biennalePopUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Storage"))
        {
            storagePopUp.gameObject.SetActive(true);
        }
        else if (collision.CompareTag("Museum"))
        {
            museumPopUp.gameObject.SetActive(true);
        }
        else if (collision.CompareTag("ParkingArea"))
        {
            parkingAreaPopUp.gameObject.SetActive(true);
        }
        else if (collision.CompareTag("Biennale"))
        {
            biennalePopUp.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Storage"))
        {
            storagePopUp.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("Museum"))
        {
            museumPopUp.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("ParkingArea"))
        {
            parkingAreaPopUp.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("Biennale"))
        {
            biennalePopUp.gameObject.SetActive(false);
        }
    }


}
