using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;

public class Enemy_NavDestintion : MonoBehaviour {
    private Enemy_Master enemyMaster;
    private NavMeshAgent myNavMesh;
    private float checkRate;
    private float nextCheck;

    void SetIntiailReferance()
    {
        enemyMaster = GetComponent<Enemy_Master>();
        if (GetComponent<NavMeshAgent>() != null)
        {
            myNavMesh = GetComponent<NavMeshAgent>();
        }

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
     CheckIfDestiontionOnReached();
    }

    private void CheckIfDestiontionOnReached()
    {
        if (enemyMaster.isOnRoute)
        {
            if (myNavMesh.remainingDistance < myNavMesh.stoppingDistance)
            {
                enemyMaster.isOnRoute = false;
                enemyMaster.CallEventEnemyReachedNavTarget();
            }
        }
    }
}
