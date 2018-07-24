using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// This code is referrenced by the website https://aiandgames.com/unity-pathfinding-part-3/.

public class Patrolling : MonoBehaviour {

    // Dictates whether there is a wait time for the AI at each node.
    [SerializeField]
    bool patrolWaiting;



    //If there is a wait time for the AI who is patrolling nodes, this is the amount of time the AI will wait.
    [SerializeField]
    float waitTime = 3;

    // This value is for the probability of switching directions.
    [SerializeField]
    float switchProbability = 0.2f;

    // This is the list of the nodes the AI can travel.
    [SerializeField]
    List<waypointScript> patrolPoints;

    // Private variables for the base behaviour
    NavMeshAgent navMeshAgent;
    int currentPatrolIndex;
    bool travelling;
    bool waiting;
    bool patrolForward;
    float waitTimer;




	// Use this for initialization
	void Start () {

        navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent is not attached to" + gameObject.name);
        }
        else
        {
            if (patrolPoints != null && patrolPoints.Count >= 2)
            {
                currentPatrolIndex = 0;
                SetDestination();
            }
            else
            {
                Debug.Log("Insufficient patrol points.");
            }
        }

	}
	
	// Update is called once per frame
	void Update () {

        // check if we are close to the destination.



        if (travelling && navMeshAgent.remainingDistance <= 1.0f)
        {
            travelling = false;

            if (patrolWaiting)
            {
                waiting = true;
                waitTimer = 0f;
            }
            else
            {
                ChangePatrolPoint();
                SetDestination();

            }
        }

        // If we are waiting..
        if (waiting)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTime)
            {
                waiting = false;


                ChangePatrolPoint();
                SetDestination();
            }
        }
	}

    void SetDestination()
    {
        if (patrolPoints != null)
        {
            Vector3 targetVector = patrolPoints[currentPatrolIndex].transform.position;
            navMeshAgent.SetDestination(targetVector);
            travelling = true;
        }
    }

    void ChangePatrolPoint()
    {
        if (UnityEngine.Random.Range(0f, 1f) <= switchProbability)
        {
            patrolForward = !patrolForward;
        }

        if (patrolForward)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Count;
        }
        else
        {
            if (--currentPatrolIndex < 0)
            {
                currentPatrolIndex = patrolPoints.Count - 1;
            }
        }
    }


}
