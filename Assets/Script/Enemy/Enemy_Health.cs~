using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour {

    private Enemy_Master enemyMaster;
    public int enemyHealth = 100;
 
  
   

    void SetIntialReferance()
    {
        enemyMaster = GetComponent<Enemy_Master>();
        
//     
        
    }

    private void OnEnable()
    {
        SetIntialReferance();
        enemyMaster.EventEnemyDedectHealth += DeductionHealth;
    }
    private void OnDisable()
    {
        enemyMaster.EventEnemyDedectHealth -= DeductionHealth;
    }
    private void DeductionHealth(int health)
    {
        enemyHealth -= health;
        if (enemyHealth <= 0)
        {
           
            enemyHealth = 0;
			GameLogic.score += 10;
            Debug.Log("Enemy Destrou");
           enemyMaster.CallEventEnemyDie();
           
         
           Destroy(gameObject, UnityEngine.Random.Range(10,20));
            
        }
    }

   

}
