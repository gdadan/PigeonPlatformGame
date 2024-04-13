using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class B : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public GameObject cctv;

    Vector3 position;

    private void Awake()
    {
        position = transform.position;
    }

   
    public void MoveCCTV()
    {
        transform.DOMoveX(cctv.transform.position.x, speed).SetDelay(1f).OnComplete(() => transform.DOMoveX(position.x,speed).SetDelay(waitTime) );
    }

    
}
