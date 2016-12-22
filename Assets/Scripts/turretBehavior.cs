using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class turretBehavior : MonoBehaviour {

	// Use this for initialization
	float rotationSpeed = 0.75f;
	public int turretID;

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(cameraRotationScript.activeTurretID == turretID && empExplosion.Shutdown == false)
		{
			if(Input.GetKey(KeyCode.D) == true)
			{
				transform.Rotate(0, rotationSpeed, 0);
			}
			if (Input.GetKey(KeyCode.A) == true)
			{
				transform.Rotate(0, -rotationSpeed, 0);
			}

		}


	}
}