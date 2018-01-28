using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour {

    private NavMeshAgent navMeshAgent;
    private Transform target;
    private bool foundTarget = false;

	// Use this for initialization
	void Start () {
        GameObject targetObj = GameObject.FindGameObjectWithTag("Player");

        if(targetObj)
        {
            target = targetObj.transform;
            foundTarget = true;
        }

        navMeshAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!foundTarget)
        {
            GameObject targetObj = GameObject.FindGameObjectWithTag("Player");
            if (targetObj)
            {
                target = targetObj.transform;
                navMeshAgent.SetDestination(targetObj.transform.position);
                foundTarget = true;
            }
        }
        else
        {
            navMeshAgent.SetDestination(target.position);
        }
	}
}
