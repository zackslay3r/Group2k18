using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This script was based off of https://aiandgames.com/unity-pathfinding-part-3/.

public class waypointScript : MonoBehaviour {

    [SerializeField]
    float debugDrawRadius = 1.0f;


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, debugDrawRadius);
    }

}
