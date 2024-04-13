using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    float gamma = 0f;

    void Start()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("Place", "Biennale");
        PlayerPrefs.SetInt("AimObject", 0);
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeInTitle());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene("ToonScene");
        }
    }

    IEnumerator FadeInTitle()
    {
        while (gamma < 1f)
        {
            spriteRenderer.color = new Color(255f, 255, 255, gamma);
            gamma += Time.deltaTime;
            yield return new WaitForSeconds(0.005f);
        }
    }
}
