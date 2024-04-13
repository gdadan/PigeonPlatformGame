using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public GameObject Ending1;

    void Start()
    {
        StartCoroutine(End());
    }

    IEnumerator End()
    {
        while (true)
        {
            Ending1.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            Ending1.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
