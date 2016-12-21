using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class startupCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("BackButton"))
        {
            InputTracking.Recenter();
        }
    }
}

