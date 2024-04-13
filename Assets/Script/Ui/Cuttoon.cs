using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cuttoon : MonoBehaviour
{
    Image img;
    public Sprite[] sprites;

    int index = 0;

    void Start()
    {
        img = GetComponent<Image>();
        img.sprite = sprites[index];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && index < 6)
        {
            index++;
            if (index == 6)
            {
                img.gameObject.SetActive(false);
                SceneManager.LoadScene("LobbyScene");
                return;
            }
            img.sprite = sprites[index];
        }

    }
}
