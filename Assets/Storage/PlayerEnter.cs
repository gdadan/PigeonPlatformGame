using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnter : MonoBehaviour
{
    public Text playerText;
    string prePlayerText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerText.gameObject.SetActive(true);
            prePlayerText = playerText.text;
            playerText.text = "...�����ϱ�";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerText.text = prePlayerText;
            playerText.gameObject.SetActive(false);
        }
    }
}
