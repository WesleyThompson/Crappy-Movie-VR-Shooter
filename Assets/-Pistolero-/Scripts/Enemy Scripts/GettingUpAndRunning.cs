using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GettingUpAndRunning : MonoBehaviour {

    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private Transform target;
    private FollowPlayer followPlayer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        followPlayer = GetComponent<FollowPlayer>();
    }

    // Use this for initialization
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("destination").transform;
        followPlayer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            EnemyRunsBack();
        }

        if (Input.GetKeyDown(KeyCode.R)){
            EnemyGetsUp();
        }
    }

    public void EnemyGetsUp()
    {
        animator.SetTrigger("GetUp");
        //EnemyRunsBack();
    }

    public void EnemyRunsBack()
    {
        animator.SetTrigger("Run");
        StartCoroutine(RunWithDelay());
    }

    public IEnumerator RunWithDelay()
    {
        yield return new WaitForSeconds(.15f);
        navMeshAgent.SetDestination(target.position);
        navMeshAgent.isStopped = false;
        navMeshAgent.speed = 2.75f;
    }
}
