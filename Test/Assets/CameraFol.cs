using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFol : MonoBehaviour {

    public float addX, addY, addZ;
    public GameObject player;

	//// Use this for initialization
	//void Start () {
		
	//}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(player.transform.position.x + addX, player.transform.position.y + addY, player.transform.position.z + addZ);


	}
}
