using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MuseumSceneManager : MonoBehaviour
{
    public GameObject player;

    public Image failEnding;
    public Image winEnding;

    public GameObject handicraft1;
    public GameObject handicraft3;

    private void Start()
    {
        PlayerPrefs.SetString("Achivement5", "Check");
    }

    private void Update()
    {
        if (!player.activeSelf) failEnding.gameObject.SetActive(true);
        if (!handicraft1.activeSelf && !handicraft3.activeSelf) winEnding.gameObject.SetActive(true);
    }
}
