using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_RagdollActivation : MonoBehaviour {

    private Enemy_Master enemyMaster;
    private Collider myCollider;
    private Rigidbody myRigidbody;

    void SetIntialRefrance()
    {
        enemyMaster = transform.root.GetComponent<Enemy_Master>();
        if (GetComponent<Collider>() != null)
        {
            myCollider = GetComponent<Collider>();


        }
        if (GetComponent<Rigidbody>() != null)
        {
            myRigidbody = GetComponent<Rigidbody>();


        }



    }

    private void OnEnable()
    {
        SetIntialRefrance();

        Debug.Log("enemy 13");
        enemyMaster.EventEnemyDie += ActiveRagdoll;
    }
    private void OnDisable()
    {
        enemyMaster.EventEnemyDie -= ActiveRagdoll;
    }
    public void ActiveRagdoll()
    {

        if (myRigidbody != null)
        {
            Debug.Log("enemy 5");
            myRigidbody.isKinematic = false;
            myRigidbody.useGravity = true;
        }

        if (myCollider != null)
        {
            Debug.Log("enemy 5");
            myCollider.isTrigger = false;
            myCollider.enabled = true;
        }
    }
}
