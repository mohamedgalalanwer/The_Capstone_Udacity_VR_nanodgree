using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;

public class Enemy_NavPuse : MonoBehaviour {

    private Enemy_Master enemyMaster;
    private NavMeshAgent myNavMesh;
    
    private float puaseTime = 1;

    IEnumerator RestartNavMeshAgent()
    {
        yield return new WaitForSeconds(puaseTime);
        enemyMaster.isNavPuse = false;
    }

    void SetIntiailReferance()
    {
        enemyMaster = GetComponent<Enemy_Master>();
        if (GetComponent<NavMeshAgent>() != null)
        {
            myNavMesh = GetComponent<NavMeshAgent>();
        }

        
    }
    private void OnEnable()
    {
        SetIntiailReferance();
        enemyMaster.EventEnemyDie += DisableThis;
        enemyMaster.EventEnemyDedectHealth += PauseNaveMeshAgent;
    }
    private void OnDisable()
    {
        enemyMaster.EventEnemyDie -= DisableThis;
        enemyMaster.EventEnemyDedectHealth -= PauseNaveMeshAgent;
    }

    private void DisableThis()
    {

        StopAllCoroutines();
    }

    // Update is called once per frame
    void PauseNaveMeshAgent(int dummy)
    {
        if (myNavMesh != null)
        {
            if (myNavMesh.enabled)
            {
                myNavMesh.ResetPath();
                enemyMaster.isNavPuse = true;
                StartCoroutine(RestartNavMeshAgent());
            }
        }
    }
}
