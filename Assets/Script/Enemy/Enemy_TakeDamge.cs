using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_TakeDamge : MonoBehaviour {

    private Enemy_Master enemyMaster;
    public int damageMultiPlayer = 1;
    public bool shouldRemoveCollider;

    void SetintialRefrance()
    {
        enemyMaster = transform.root.GetComponent<Enemy_Master>();

    }
    private void OnEnable()
    {
        SetintialRefrance();
        enemyMaster.EventEnemyDie += RemoveThis;
    }
    private void OnDisable()
    {
        enemyMaster.EventEnemyDie -= RemoveThis;
    }
    private void RemoveThis()
    {
        if (shouldRemoveCollider)
        {
            if (GetComponent<Collider>() != null)
            {
                Destroy(GetComponent<Collider>());
            }
            if (GetComponent<Rigidbody>() != null)
            {
                Destroy(GetComponent<Rigidbody>());
            }
        }
        Destroy(this);
    }

    public void ProcessDamage(int damage)
    {
        int damageToApplay = damage * damageMultiPlayer;
        enemyMaster.CallDedectedHealth(damageToApplay);

    }
}
