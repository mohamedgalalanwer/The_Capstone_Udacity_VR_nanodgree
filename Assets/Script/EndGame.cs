using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

   
        void Awake() {
            Input.backButtonLeavesApp = true;
        }
        // Use this for initialization
        void Start () {
            Debug.Log("Starting up BackHandler");  
        }

        // Update is called once per frame
        void Update () {
            if (Input.GetKeyUp(KeyCode.Escape)) {
                Debug.Log("Goodbye cruel world!");
                Application.Quit();
            }
        }
    }

