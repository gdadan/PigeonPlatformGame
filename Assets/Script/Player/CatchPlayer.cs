using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchPlayer : MonoBehaviour
{
    public Text catchGuide;

    public Image endStage;

    AudioSource audiosource;
    public AudioClip getSource;
    
    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Handicraft") || collision.CompareTag("Handicraft1") || collision.CompareTag("Handicraft2") || collision.CompareTag("Handicraft3") || collision.CompareTag("Handicraft4") || collision.CompareTag("Rip") || collision.CompareTag("MirrorBall"))
        {
            catchGuide.gameObject.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.CompareTag("Handicraft") || collision.CompareTag("Handicraft1") || collision.CompareTag("Handicraft2") || collision.CompareTag("Handicraft3") || collision.CompareTag("Handicraft4") || collision.CompareTag("MirrorBall")) && Input.GetKey(KeyCode.A))
        { 
            collision.gameObject.SetActive(false);
            PlayerPrefs.SetString(collision.tag, "Acquire");
            PlayerPrefs.SetInt("AimObject", PlayerPrefs.GetInt("AimObject") + 1);
            audiosource.clip = getSource;
            audiosource.Play();
        }
        else if (collision.CompareTag("Rip") && Input.GetKey(KeyCode.A))
        {
            collision.transform.Find("Canvas").gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Handicraft") || collision.CompareTag("Handicraft1") || collision.CompareTag("Handicraft2") || collision.CompareTag("Handicraft3") || collision.CompareTag("Handicraft4") || collision.CompareTag("Rip") || collision.CompareTag("MirrorBall"))
        {
            catchGuide.gameObject.SetActive(false) ;
        }
    }
}
