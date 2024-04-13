using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Image ending;
    public GameObject mirrorBall;

    private void Update()
    {
        Ending();
    }

    void Ending()
    {
        if (!mirrorBall.activeSelf)
        {
            ending.gameObject.SetActive(true);
        }
    }
    
}
