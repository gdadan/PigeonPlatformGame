using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AzitManager : MonoBehaviour
{
    public GameObject mirrorBallBack, handicraft, handicraft1, handicraft2, handicraft3, handicraft4, mirrorBallLight;
    public GameObject pigeon1, pigeon2;

    private void Start()
    {
        PlayerPrefs.SetString("Achivement2", "Check");

        if (PlayerPrefs.GetString("MirrorBall") == "Acquire" && PlayerPrefs.GetString("Handicraft") == "Acquire" && PlayerPrefs.GetString("Handicraft1") == "Acquire" && PlayerPrefs.GetString("Handicraft2") == "Acquire" && PlayerPrefs.GetString("Handicraft3") == "Acquire" && PlayerPrefs.GetString("Handicraft4") == "Acquire")
        {
            SetBGM3();
            Invoke("GoEnd", 10f);
        }
    }

    private void Update()
    {
        if (PlayerPrefs.GetString("MirrorBall") == "Acquire") mirrorBallBack.SetActive(false);
        if (PlayerPrefs.GetString("Handicraft") == "Acquire") handicraft.SetActive(true);
        if (PlayerPrefs.GetString("Handicraft1") == "Acquire") handicraft1.SetActive(true);
        if (PlayerPrefs.GetString("Handicraft2") == "Acquire") handicraft2.SetActive(true);
        if (PlayerPrefs.GetString("Handicraft3") == "Acquire") handicraft3.SetActive(true);
        if (PlayerPrefs.GetString("Handicraft4") == "Acquire") handicraft4.SetActive(true);

        if (handicraft1.activeSelf && handicraft3.activeSelf) pigeon1.SetActive(true);
        if (handicraft2.activeSelf && handicraft4.activeSelf) pigeon2.SetActive(true);

        if (handicraft.activeSelf) mirrorBallLight.SetActive(true);
    }

    void GoEnd()
    {
        SceneManager.LoadScene("EndingScene");
    }

    public void SetBGM3()
    {
        AudioManager audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        AudioSource audio = audioManager.GetComponent<AudioSource>();

        audio.Stop();

        audio.clip = audioManager.bgm3;

        audio.Play();
    }
}
