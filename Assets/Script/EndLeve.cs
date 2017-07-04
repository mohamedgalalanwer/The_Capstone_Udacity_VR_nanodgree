using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLeve : MonoBehaviour {
    public GameObject UIgameObject;
    public Text scoreText;
    // Use this for initialization
    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
			if ( GameLogic.score >= 500)
            {
                UIgameObject.SetActive(true);
				scoreText.text = "Score : " + GameLogic.score;

                StartCoroutine(WaitAndPrint());
            }
        }
    }

    IEnumerator WaitAndPrint()
    {
        yield return new WaitForSeconds(5f);
		Application.LoadLevel("Main");
    }


    void Update(){
    
    
    }
    }
