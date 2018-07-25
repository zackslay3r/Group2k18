using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementplane : MonoBehaviour {

    // We are going to need a reference to the possession script so that we can know what the camera's target is.
    public Possession mainCamera;
    // Use this for initialization
    public float speedMultiplier;
	void Start () {

        // Check if we have a reference to the camera. if we dont, send a debug.log message.
        if (mainCamera == null)
        {
            Debug.Log("You do not have the main camera linked, therefor, a possessable object does not know the camera's main target.");
        }


	}
	
	// Update is called once per frame
	void Update () {

        Movement();

	}

    void Movement()
    {
        if (mainCamera.currentCharacter == gameObject)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.position = new Vector3(transform.position.x - 1 * speedMultiplier, transform.position.y, transform.position.z);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position = new Vector3(transform.position.x + 1 * speedMultiplier, transform.position.y, transform.position.z);
            }
        }
    }
}
