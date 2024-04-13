using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    Animator anim;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim = GetComponentInParent<Animator>();
            transform.parent.gameObject.GetComponent<Enemy>().state = "Follow";
            anim.SetTrigger("surpri");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {           
            transform.parent.gameObject.GetComponent<Enemy>().state = "Move";
        }
    }
}
