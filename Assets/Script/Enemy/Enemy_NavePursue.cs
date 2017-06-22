using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;
public class Enemy_NavePursue : MonoBehaviour {

    private Enemy_Master enemyMaster;
    private NavMeshAgent myNavMesh;
    private float checkRate;
    private float nextCheck;



	// Use this for initialization
	void SetIntiailReferance () {
        enemyMaster = GetComponent<Enemy_Master>();
        if (GetComponent<NavMeshAgent>() != null)
        {
            myNavMesh = GetComponent<NavMeshAgent>();
        }

        checkRate = UnityEngine.Random.Range(0.1f, 0.2f);
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
        if (myNavMesh != null)
        {
            myNavMesh.enabled = false;
        }
        this.enabled = false;
    }

    // Update is called once per frame
    void Update () {
        if (Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
        }
        TrytoCheckTarget();
	}

    private void TrytoCheckTarget()
    {
        if(enemyMaster.myTarget!=null&&
            myNavMesh!=null
            &&!enemyMaster.isNavPuse)
        {
            print("enamy walk");
            myNavMesh.SetDestination(enemyMaster.myTarget.position);

        }
        if (myNavMesh.remainingDistance > myNavMesh.stoppingDistance)
        {
            enemyMaster.CallEventEnemyWalking();
            print("Is On Route");
            enemyMaster.isOnRoute = true;
        }
    }
}
