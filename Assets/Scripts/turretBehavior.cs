using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class turretBehavior : MonoBehaviour {

	// Use this for initialization
	float rotationSpeed = 0.75f;//0.25f;
	vrBehavior referenceFile;
	public int turretID;
	void Start () {
		referenceFile = new vrBehavior();

	}

	// Update is called once per frame
	void Update () {
		referenceFile.Update();
		if(referenceFile.turretControl == turretID && empExplosion.Shutdown == false)
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