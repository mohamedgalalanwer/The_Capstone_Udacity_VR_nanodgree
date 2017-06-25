using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour {

    public GameObject objectToSpawen;
    public int numberToSpawen;
    public float proximity;
    private float checkRate;
    private float nextCheck;
    private Transform myTransform;
    public Transform playerTransform;
    private Vector3 spawenPostion;


    void SetIntialRefrance()
    {
        myTransform = transform;
        checkRate = UnityEngine.Random.Range(0.8F, 1.2F);


    }
	void Start () {
        SetIntialRefrance();
	}
	
	// Update is called once per frame
	void Update () {
        CheckDistance();
	}

    private void CheckDistance()
    {
        nextCheck = Time.time + checkRate;
        if (Vector3.Distance(myTransform.position, playerTransform.position) < proximity)
        {
            SpawenObject();
            this.enabled = false;
        }
    }

    private void SpawenObject()
    {
       for(int i = 0; i <= numberToSpawen; i++)
        {

            spawenPostion = myTransform.position + UnityEngine.Random.insideUnitSphere * 7;
            Instantiate(objectToSpawen, spawenPostion, myTransform.rotation);
        }
    }
}
