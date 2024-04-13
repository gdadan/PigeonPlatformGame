using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip bgm1, bgm2, bgm3;

    AudioSource audiosource;

    string bgm;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }
    
    public void TitleAndLobbyBGM()
    {
        audiosource.Stop();
        audiosource.clip = bgm1;
        audiosource.Play();
    }

    public void StageBGM()
    {
        audiosource.Stop();
        audiosource.clip = bgm2;
        audiosource.Play();
    }
}
