using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    bool canBroken = false;

    public GameObject piecePrefab;

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canBroken = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && canBroken)
        {
            GameObject pieces = Instantiate(piecePrefab);
            pieces.transform.position = transform.position;
            gameObject.SetActive(false);
        }
    }
}
