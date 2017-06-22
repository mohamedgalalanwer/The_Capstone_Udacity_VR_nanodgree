using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class Player_Health : MonoBehaviour {

    private Player_Master playerMaster;
    public int playerHealth;
    public Text healthText;
   
	//void Start () {
 //      // StartCoroutine(TestHealthDeduction());
	//}

 //   private IEnumerator TestHealthDeduction()
 //   {
 //       yield return new WaitForSeconds(4);
 //       DeductionHealth(100);
 //   }

    private void DeductionHealth(int damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            playerHealth = 0;
            Debug.Log("Enabled");

            //////////////////////////////////--------------Player die----------------------////////////////

            Application.LoadLevel("GameOver");

 
        }
      SetUI();
    }

    private void SetUI()
    {
        if (healthText != null)
        {
            healthText.text ="Health : "+ playerHealth.ToString();
        }
    }

    void SetOnIntialRefrance()
    {
        playerMaster = GetComponent<Player_Master>();

    }
    private void OnEnable()
    {
        SetOnIntialRefrance();
        playerMaster.EventPlayerHealthDeduction += DeductionHealth;
        playerMaster.EventPlayerHealthIncrease += IncreaseHealth;
    }

    private void OnDisable()
    {
        playerMaster.EventPlayerHealthDeduction -= DeductionHealth;
        playerMaster.EventPlayerHealthIncrease -= IncreaseHealth;
    
}
    private void IncreaseHealth(int healthChange)
    {
        playerHealth += healthChange;
        if (playerHealth > 100)
        {
            playerHealth = 100;

        }
      SetUI();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
