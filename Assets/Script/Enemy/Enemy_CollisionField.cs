using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_CollisionField : MonoBehaviour {

    private Enemy_Master enemyMaster;
    private Rigidbody rigidbodyStriking;
   private int damageToApplay;
  
    private float damageFator = 0.1f;
    AudioSource audio;
    void DisableThis()
    {
        gameObject.SetActive(false);

    }

    private void OnEnable()
    {
        SetIntialReferanc();
        enemyMaster.EventEnemyDie += DisableThis;
    }
    private void OnDisable()
    {
        enemyMaster.EventEnemyDie -= DisableThis;
    }

    private void SetIntialReferanc()
    {
        enemyMaster = transform.root.GetComponent<Enemy_Master>();
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {

   
        if (other.CompareTag("Hit"))
        {




            Debug.Log("enemy die5");
            audio.Play();
            damageToApplay = 50;
            enemyMaster.CallDedectedHealth(damageToApplay);
          




        }
    }
}
