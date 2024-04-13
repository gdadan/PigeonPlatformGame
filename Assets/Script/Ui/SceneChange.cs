using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void Scene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }

    public void SetPlace(string place)
    {
        PlayerPrefs.SetString("Place", place);
    }

    public void SetBGM1()
    {
        AudioManager audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        AudioSource audio = audioManager.GetComponent<AudioSource>();

        audio.Stop();

        audio.clip = audioManager.bgm1;

        audio.Play();
    }

    public void SetBGM2()
    {
        AudioManager audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        AudioSource audio = audioManager.GetComponent<AudioSource>();

        audio.Stop();

        audio.clip = audioManager.bgm2;

        audio.Play();
    }

    public void SetBGM3()
    {
        AudioManager audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        AudioSource audio = audioManager.GetComponent<AudioSource>();

        audio.Stop();

        audio.clip = audioManager.bgm3;
        Debug.Log(audio.clip);
        audio.Play();
    }
}
