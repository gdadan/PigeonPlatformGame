using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageManager : MonoBehaviour
{
    public GameObject handicraft, handicraft2, handicraft4;
    public GameObject player;
    public Image winEnding;

    private void Start()
    {
        PlayerPrefs.SetString("Achivement4", "Check");
    }
    private void Update()
    {
        Ending();
    }

    void Ending()
    {
        if (!handicraft.activeSelf && !handicraft2.activeSelf && !handicraft4.activeSelf)
        {
            winEnding.gameObject.SetActive(true);
        }
    }
}
