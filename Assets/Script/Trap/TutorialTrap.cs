using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = new Vector3(-7.55f, -2.82f, 0);           
        }
    }
}
