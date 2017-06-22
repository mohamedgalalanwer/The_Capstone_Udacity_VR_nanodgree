using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartNewGame : MonoBehaviour {

    

	public void WaitAndPrint()
    {
        // suspend execution for 5 seconds
        //yield return new WaitForSeconds(1);
       //s print("WaitAndPrint " + Time.time);
		// Application.LoadLevel("Game");
		SceneManager.LoadScene ("Game");
    }

    
}

