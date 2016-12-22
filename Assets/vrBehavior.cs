using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class vrBehavior : MonoBehaviour {


    Quaternion currentRotation;
    public int turretControl;

    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	public void Update () {
        currentRotation = Camera.main.transform.localRotation;
        if (currentRotation.eulerAngles.y >= 0 && currentRotation.eulerAngles.y < 120)
        {
            turretControl = 1;

            //print(currentRotation.eulerAngles.y.ToString() + "," + turretControl.ToString());
        }
        else if (currentRotation.eulerAngles.y >= 120 && currentRotation.eulerAngles.y < 240)
        {
            turretControl = 2;
            //print(currentRotation.eulerAngles.y.ToString() + "," + turretControl.ToString());
        }
        else if (currentRotation.eulerAngles.y >= 240 && currentRotation.eulerAngles.y <= 360)
        {
            turretControl = 3;
           // print(currentRotation.eulerAngles.y.ToString() + "," + turretControl.ToString());
        }
        
    }

}
