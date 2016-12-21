using UnityEngine;
using System.Collections;

public class barrelBehavior : MonoBehaviour {

    // Use this for initialization
	float barrelSpeed = 0.75f;//0.25f;
    int state = 3; //Up direction enabled
    vrBehavior referenceFile;
    public int turretID;

    void Start()
    {
        referenceFile = new vrBehavior();
    }

    // Update is called once per frame
    void Update() {
        #region barrelRotation
        referenceFile.Update();
        if (referenceFile.turretControl == turretID)
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
                        //print(transform.eulerAngles.z);
                    }
                    break;
                case 2: //both directions enabled
                    if (Input.GetKey(KeyCode.W) == true)
                    {
                        //Move barrel up
                        transform.Rotate(0, 0, barrelSpeed);
                        //print(transform.eulerAngles.z);
                    }
                    else if (Input.GetKey(KeyCode.S) == true)
                    {
                        //Move barrel down
                        transform.Rotate(0, 0, -barrelSpeed);
                        //print(transform.eulerAngles.z);
                    }
                    break;
                case 3: //down is disabled
                    if (Input.GetKey(KeyCode.W) == true)
                    {
                        //Move barrel up
                        transform.Rotate(0, 0, barrelSpeed);
                        //print(transform.eulerAngles.z);
                        //print("State 3!");
                    }
                    break;

            }
        }
        #endregion

       

    }

  
}
