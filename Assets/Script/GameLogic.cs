using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {
	public Text scoreText;
	public static int  score ;
	// Use this for initialization
	void Start(){
		score = 0;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		scoreText.text = "Score : " + score;
	}
}
