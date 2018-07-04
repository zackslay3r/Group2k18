using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This follow is based off of https://answers.unity.com/questions/31582/need-camera-to-follow-player-but-not-the-players-r.html

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    
    public float cameraHeight = 20.0f;

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - cameraHeight);

        //transform.position.z = player.transform.position.z - cameraHeight;
        //transform.position.y = target.position.y;
        //transform.position.x = target.position.x;

    }
}
