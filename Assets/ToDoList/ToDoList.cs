using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToDoList : MonoBehaviour
{
    public Text aim;
    public Image stamp1, stamp2, stamp3, stamp4, stamp5;            
    private void Update()
    {
        aim.text = string.Format("나에게 어울리는 멋진 물건 가져오기 ({0}/6)", PlayerPrefs.GetInt("AimObject"));

        if (PlayerPrefs.GetInt("AimObject") >= 6)
        {
            PlayerPrefs.SetString("Achivement1", "Check");
        }

        if (Input.GetKey(KeyCode.Tab))
        {
            transform.position += Vector3.up * 10f;
        }
        else
        {
            transform.position += Vector3.down * 8f;
        }

        if (transform.position.y < -1200)
        {
            transform.position = new Vector3(transform.position.x, -1200, transform.position.z);
        }
        else if (transform.position.y > 500)
        {
            transform.position = new Vector3(transform.position.x, 500, transform.position.z);
        }

        if (PlayerPrefs.GetString("Achivement1") == "Check") stamp1.gameObject.SetActive(true);
        if (PlayerPrefs.GetString("Achivement2") == "Check") stamp2.gameObject.SetActive(true);
        if (PlayerPrefs.GetString("Achivement3") == "Check") stamp3.gameObject.SetActive(true);
        if (PlayerPrefs.GetString("Achivement4") == "Check") stamp4.gameObject.SetActive(true);
        if (PlayerPrefs.GetString("Achivement5") == "Check") stamp5.gameObject.SetActive(true);
    }
}
