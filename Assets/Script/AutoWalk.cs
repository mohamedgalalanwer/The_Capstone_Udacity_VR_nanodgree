using UnityEngine;
using System.Collections;

public class AutoWalk : MonoBehaviour {

    public Transform vrCamera;
    public GameObject UICanvas;
    public float togglengle = 25.0f;
    public float speed = 3f;
    public  bool movForawerd;
    private CharacterController cc;

    // Use this for initialization
    void Start () {
        cc = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update () {
        if (vrCamera.eulerAngles.x >= togglengle && vrCamera.eulerAngles.x < 90f)
        {

            movForawerd = true;

            UICanvas.SetActive (false);
        }
        else
        {
            movForawerd = false;
            UICanvas.SetActive (true);
        }

        if (movForawerd)
        {

            Vector3 f = vrCamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(f * speed);


        }
    }
}
