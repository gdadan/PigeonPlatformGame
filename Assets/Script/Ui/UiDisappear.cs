using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiDisappear : MonoBehaviour
{
    [SerializeField] float disappearTime = 1f;
    [SerializeField] float gammaTime = 0.005f;

    public Text tutorialText;

    float gamma = 1f;

    void Start()
    {
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(disappearTime);
        while (gamma > 0)
        {
            gamma -= Time.deltaTime;
            tutorialText.color = new Color(255, 255, 255, gamma);
            yield return new WaitForSeconds(gammaTime);

            if (gamma < 0) gameObject.SetActive(false);
        }
    }
}
