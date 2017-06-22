using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour {

    private Enemy_Master enemyMaster;
    private Transform myTransform;
                            public Transform head;
    public LayerMask playerLayer;
    public LayerMask sightLayer;
    private float checkRate;
    private float nextRate;
    public float detectedRaduis = 80;
    private RaycastHit hit;

	

    void DisableThis()
    {
        this.enabled = false;

    }

    void SetIntialRefrence()
    {

        enemyMaster = GetComponent<Enemy_Master>();
        myTransform = transform;
        if (head == null)
        {

            head = myTransform;
        }

        checkRate = UnityEngine.Random.Range(0.8f, 1.2f);
    }

    private void OnEnable()
    {
        SetIntialRefrence();
        enemyMaster.EventEnemyDie += DisableThis;
    }

    private void OnDisable()
    {
        enemyMaster.EventEnemyDie -= DisableThis;

    }


    void Update () {
        CarryOutDetection();
	}

    private void CarryOutDetection()
    {
        if (Time.time > nextRate)
        {
            nextRate = Time.time + checkRate;
            Collider[] colliders = Physics.OverlapSphere(myTransform.position, detectedRaduis, playerLayer);
            if (colliders.Length > 0)
            {

                foreach(Collider potentialTargetCollider in colliders)
                {
                    if (potentialTargetCollider.CompareTag("Player"))
                    {

                        if (CanPotentialTargetBeSeen(potentialTargetCollider.transform))
                        {
                            print("Player insight");
                            break;
                        }
                    }

                }
            }
            else
            {

                enemyMaster.CallEventEnemyLostTarget();
            }
        }
        
    }


    bool CanPotentialTargetBeSeen(Transform potentialTarget)
    {

        if(Physics.Linecast(head.position,potentialTarget.position,out hit, sightLayer))
        {

            if (hit.transform == potentialTarget)
            {
                enemyMaster.CallEventEnemySetNavTarget(potentialTarget);
                return true;

            }
            else
            {
                enemyMaster.CallEventEnemyLostTarget();
                return false;
            }
        }
        else
        {
            enemyMaster.CallEventEnemyLostTarget();
            return false;
        }


    }
}
