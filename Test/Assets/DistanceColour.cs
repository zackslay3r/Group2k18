using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceColour : MonoBehaviour {

    // We need a reference to the possession script for the purposes of finding out the current character.
    public Possession posScript;

    public float distanceAway = 25;
	
	// Update is called once per frame
	void Update () {


        // Make a glow effect happen if the player is within a certain rangle of a possessable object





       
        


            // the distance away from the player
            float testDistance = Vector3.Distance(transform.position, posScript.currentCharacter.transform.position);

        
        if (testDistance < distanceAway && posScript.currentCharacter != gameObject)
        {
            
                gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        } 
        else
            {
                gameObject.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
            }



        
    }
}
