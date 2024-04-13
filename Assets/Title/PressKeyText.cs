using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressKeyText : MonoBehaviour
{
    Text pressKeyText;

    float gamma = 0f;
    
    void Start()
    {
        pressKeyText = GetComponent<Text>();
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeInText());
    }
    IEnumerator FadeInText()
    {
        while (gamma < 1f)
        {
            pressKeyText.color = new Color(255f, 255, 255, gamma);
            gamma += Time.deltaTime;
            yield return new WaitForSeconds(0.005f);
        }
        StartCoroutine(FadeOutText());
    }

    IEnumerator FadeOutText()
    {
        while (gamma > 0f)
        {
            pressKeyText.color = new Color(255f, 255, 255, gamma);
            gamma -= Time.deltaTime;
            yield return new WaitForSeconds(0.005f);
        }
        StartCoroutine(FadeInText());
    }
}
