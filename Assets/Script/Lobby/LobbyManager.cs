using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public GameObject comepleteBien, completeMus, completeStor;
    public GameObject player;

    private void Start()
    {
        if (PlayerPrefs.GetString("Place") == "Biennale")
        {
            player.transform.position = new Vector3(11f, 3.76f, 0);
        }  
        else if (PlayerPrefs.GetString("Place") == "Museum")
        {
            player.transform.position = new Vector3(69.32f, 3.76f, 0);
        }
        else if (PlayerPrefs.GetString("Place") == "Azit")
        {
            player.transform.position = new Vector3(101.59f, 3.76f, 0);
        }
        else if (PlayerPrefs.GetString("Place") == "Storage")
        {
            player.transform.position = new Vector3(153.3f, 3.76f, 0);
        }

    }

    private void Update()
    {
        if (PlayerPrefs.GetString("MirrorBall") == "Acquire") comepleteBien.SetActive(true);
        if (PlayerPrefs.GetString("Handicraft1") == "Acquire" && PlayerPrefs.GetString("Handicraft3") == "Acquire") completeMus.SetActive(true);
        if (PlayerPrefs.GetString("Handicraft") == "Acquire" && PlayerPrefs.GetString("Handicraft2") == "Acquire" && PlayerPrefs.GetString("Handicraft4") == "Acquire") completeStor.SetActive(true);
    }

    public void SetPlace(string place)
    {
        PlayerPrefs.SetString("Place", place);
    }
}
