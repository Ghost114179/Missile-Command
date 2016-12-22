using UnityEngine;
using System.Collections;

public class barrelBehavior : MonoBehaviour {

    // Use this for initialization
	float barrelSpeed = 0.75f;
    int state = 3; 
    public int turretID;

    void Start(){
    }

    // Update is called once per frame
    void Update() {
		if (cameraRotationScript.activeTurretID == turretID && empExplosion.Shutdown == false)
        {
            if (transform.eulerAngles.z < 90 && transform.eulerAngles.z > 0) //In between targets!
            {
                state = 2;
            }
            else if (transform.eulerAngles.z >= 90 && transform.eulerAngles.z < 95) //Disable up
            {
                state = 1;
            }
            else
            {
                state = 3;
            }

            switch (state)
            {
                case 1: //up is disabled
                    if (Input.GetKey(KeyCode.S) == true)
                    {
                        //Move barrel down
                        transform.Rotate(0, 0, -barrelSpeed);
                    }
                    break;
                case 2: //both directions enabled
                    if (Input.GetKey(KeyCode.W) == true)
                    {
                        //Move barrel up
                        transform.Rotate(0, 0, barrelSpeed);
                    }
                    else if (Input.GetKey(KeyCode.S) == true)
                    {
                        //Move barrel down
                        transform.Rotate(0, 0, -barrelSpeed);
                    }
                    break;
                case 3: //down is disabled
                    if (Input.GetKey(KeyCode.W) == true)
                    {
                        //Move barrel up
                        transform.Rotate(0, 0, barrelSpeed);
                    }
                    break;
            }
        }
	}
}
