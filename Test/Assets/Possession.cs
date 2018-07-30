using System.Collections;
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
    void Update() {

        





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
                    // test variable to test out the distance
                    float testDistance = Vector3.Distance(currentCharacter.transform.position, characters.transform.position);

                    
                    if (testDistance < distanceAway)
                    {
                        
                        if (swapped == false)
                        {
                            characters.transform.position = new Vector3(characters.transform.position.x, characters.transform.position.y, 25);
                            if (currentCharacter.GetComponent<PlayerMovement>() != null && currentCharacter.GetComponent<Animator>() != null)
                            {
                                currentCharacter.GetComponent<PlayerMovement>().enabled = false;
                                currentCharacter.GetComponent<Animator>().enabled = false;
                            }
                            currentCharacter.transform.position = new Vector3(currentCharacter.transform.position.x, currentCharacter.transform.position.y, 42);
                            currentCharacter = characters;
                            mainCamera.player = characters;
                            if (currentCharacter.GetComponent<PlayerMovement>() != null && currentCharacter.GetComponent<Animator>() != null)
                            {
                                currentCharacter.GetComponent<PlayerMovement>().enabled = true;
                                currentCharacter.GetComponent<Animator>().enabled = true;
                            }
                            
                            
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
