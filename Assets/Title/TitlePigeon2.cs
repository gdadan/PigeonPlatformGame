using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePigeon2 : MonoBehaviour
{
    float pigeonSpeed = 3f;
    void Update()
    {
        transform.position += new Vector3(-1, 1, 0) * Time.deltaTime * pigeonSpeed;
    }
}
