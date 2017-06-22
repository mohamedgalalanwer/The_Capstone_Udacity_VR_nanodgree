using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WepoanSway : MonoBehaviour {

    public float amount;
    public float smootAmount;
    private Vector3 intialPostion;
    public float maxAmount;



	// Use this for initialization
	void Start () {
        intialPostion = transform.localPosition;

	}
	
	// Update is called once per frame
	void Update () {
        float movementX = -Input.GetAxis("Mouse X") * amount;
        float movementY = -Input.GetAxis("Mouse Y") * amount;
        movementX = Mathf.Clamp(movementX, -maxAmount, maxAmount);
        movementY = Mathf.Clamp(movementY, -maxAmount, maxAmount);
        Vector3 finalPostion = new Vector3(movementX, movementY, 0);
            
           transform.localPosition  = Vector3.Lerp(transform.localPosition, intialPostion + finalPostion, Time.deltaTime * smootAmount);


    }
}
