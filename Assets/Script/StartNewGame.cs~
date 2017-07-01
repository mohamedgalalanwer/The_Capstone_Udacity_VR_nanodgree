using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartNewGame : MonoBehaviour {


    public GameObject uiCanvas1;
    public GameObject uiCanvas2;


	public void WaitAndPrint()
    {
        // suspend execution for 5 seconds
        //yield return new WaitForSeconds(1);
       //s print("WaitAndPrint " + Time.time);
		// Application.LoadLevel("Game");
		SceneManager.LoadScene ("Game");
    }
    public  void InstructionVisable()
    {
        uiCanvas1.SetActive(false);
        uiCanvas2.SetActive(true);

    }
    public void InstructionVisable1()
    {
        uiCanvas1.SetActive(true);
        uiCanvas2.SetActive(false);

    }
    public void QuitGame(){
        Application.Quit();
    
    }


    
}

