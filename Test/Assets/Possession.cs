﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Possession : MonoBehaviour {

    // This will contain the list of the controllable characters.

    public GameObject[] possessables;

    //This is the current possessible character;

    public GameObject currentCharacter;


    public float distanceAway;

    // This is the camera.
    public CameraFol mainCamera;
    
	// Use this for initialization
	void Start () {
        currentCharacter = mainCamera.player; 
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            bool swapped = false;
            foreach (GameObject characters in possessables)
            {
                if (characters == currentCharacter)
                {
                    continue;
                }
                else
                {
                    if (Vector3.Distance(currentCharacter.transform.position, characters.transform.position) < distanceAway)
                    {


                        if (swapped == false)
                        {
                            currentCharacter.GetComponent<PlayerMovement>().enabled = false;
                            currentCharacter.GetComponent<Animator>().enabled = false;
                            currentCharacter = characters;
                            mainCamera.player = characters;
                            currentCharacter.GetComponent<PlayerMovement>().enabled = true;
                            currentCharacter.GetComponent<Animator>().enabled = true;
                            swapped = true;
                        }
                        else
                        {
                            continue;
                        }
                    
                    };
                }
            }
        }

	}
}
