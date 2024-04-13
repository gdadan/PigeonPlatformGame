using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyCamera : MonoBehaviour
{
    public GameObject player;

    private void Update()
    {
        transform.position = new Vector3 (player.transform.position.x + 3, transform.position.y, transform.position.z);
    }
}
