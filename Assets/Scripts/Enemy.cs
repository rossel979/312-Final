using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;

    NavMeshAgent navMeshAgent;

    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    bool blnIsTransitioning;
    bool blncollisionDisabled;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked) 
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange) 
        {
            isProvoked = true;
            //navMeshAgent.SetDestination(target.position);
        }
        
    }
    private void EngageTarget() 
    { 
        if (distanceToTarget >= navMeshAgent.stoppingDistance) 
        {
            ChaseTarget();
        }
        
        if (distanceToTarget <= navMeshAgent.stoppingDistance) 
        {
            AttackTarget();
        }

       
    }
    private void ChaseTarget() 
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget() 
    {
        Debug.Log("gottem");
    }
    private void OnCollisionEnter(Collision other)
    {
        SceneManager.LoadScene(0);
    }
}
