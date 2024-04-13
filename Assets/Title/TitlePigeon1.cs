using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePigeon1 : MonoBehaviour
{
    float pigeonSpeed = 3f;
    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * pigeonSpeed;
    }
}
