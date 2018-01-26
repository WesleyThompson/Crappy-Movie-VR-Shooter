using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour {

    private NavMeshAgent navMeshAgent;
    public Transform target;

	// Use this for initialization
	void Start () {

        navMeshAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {

        navMeshAgent.SetDestination(target.position);
	}
}
