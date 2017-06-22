using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;

public class Enemy_NavWander : MonoBehaviour {

    private Enemy_Master enemyMaster;
    private NavMeshHit navHit;
    private NavMeshAgent myNavMesh;
    private float checkRate;
    private float nextCheck;
    private float wanderRange = 10;
    private Transform myTransform;
    private Vector3 wanderTarget;


    // Use this for initialization
    void SetIntiailReferance()
    {
        enemyMaster = GetComponent<Enemy_Master>();
        if (GetComponent<NavMeshAgent>() != null)
        {
            myNavMesh = GetComponent<NavMeshAgent>();
        }
        myTransform = transform;
        checkRate = UnityEngine.Random.Range(0.3f, 0.4f);
    }

    private void OnEnable()
    {
        SetIntiailReferance();
        enemyMaster.EventEnemyDie += DisableThis;
    }
    private void OnDisable()
    {
        enemyMaster.EventEnemyDie -= DisableThis;
    }

    private void DisableThis()
    {
        
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
        }
        TrytoCheckIfShouldWanderd();
    }

    private void TrytoCheckIfShouldWanderd()
    {
       if(enemyMaster.myTarget==null&&
            !enemyMaster.isOnRoute
            &&!enemyMaster.isNavPuse)
        {

            if(RandomWanderTarget(myTransform.position,wanderRange,out wanderTarget))
            {
                myNavMesh.SetDestination(wanderTarget);
                enemyMaster.isOnRoute = true;
                print("enamy walk");
                enemyMaster.CallEventEnemyWalking();
            }
        }
    }
    bool RandomWanderTarget(Vector3 center ,float range,out Vector3 result)
    {
        Vector3 randomPoint = center + UnityEngine.Random.insideUnitSphere * wanderRange;
        if (NavMesh.SamplePosition(randomPoint,out navHit, 1.0f, NavMesh.AllAreas))
        {

            result = navHit.position;
            return true;
        }
        else
        {
            result = center;
            return false;
        }
    }
}
