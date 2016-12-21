using UnityEngine;

using System.Collections;

public class cameraRotationScript : MonoBehaviour {

	public static float rotationSpeed = 1.25f;
    float rotSpeedX;
    float rotSpeedY;
	public static float multX = 0.3f;
	public static float multY = 0.3f;
	int screenWidth = Screen.width;
	int screenHeight = Screen.height;
	float xRotation;
	int State = 0;

	// Use this for initialization
	void Start () {
        //Cursor.visible = false;
	}

	int getState() {
		xRotation = transform.localEulerAngles[0];
		//print("X-Rotation: " + xRotation + "; Direction: " + transform.localEulerAngles);

		if ((xRotation > 270 || xRotation < 90) && (Mathf.Pow(transform.localEulerAngles[2], 2) < 1.0)) {
			return 0;
		} else if (xRotation <= 275 && xRotation >= 180) {
			return 1;
		} else if (xRotation >= 85 && xRotation < 180) {
			return 2;
		} else {
			return 3;
		}

	}
	
	// Update is called once per frame
	void Update () {
		rotSpeedY = 0;
		if (Input.mousePosition.x < (int)((screenWidth / 2) * (1 - multX)) || Input.mousePosition.x > (int)((screenWidth / 2) * (1 + multX))) {
			rotSpeedX = -1 + 2 * (Input.mousePosition.x / screenWidth);
			Camera.main.transform.Rotate(0f, rotationSpeed * rotSpeedX, 0f, Space.World);
		}

        State = getState();
		//State = 0;
		//print("Rotation: " + transform.rotation);
        //print ("State: " + State.ToString());
        switch (State) {
		case (0):
			if (Input.mousePosition.y < (int)((screenHeight / 2) * (1 - multY)) || Input.mousePosition.y > (int)((screenHeight / 2) * (1 + multY))) {
				rotSpeedY = -1 + 2 * (Input.mousePosition.y / screenHeight);
				//print (" 0 Speed: " + rotSpeedY.ToString ());
			}
			break;
		case (2):
			if (Input.mousePosition.y > (int)(screenHeight / 2) * (1 + multY)) {
				rotSpeedY = -1 + 2 * (Input.mousePosition.y / screenHeight);
				//print (" 2 Speed: " + rotSpeedY.ToString ());
			}
			break;
		case (1):
			if (Input.mousePosition.y < (int)((screenHeight / 2) * (1 - multY))) {
				rotSpeedY = -1 + 2 * (Input.mousePosition.y / screenHeight);
				//print (" 1 Speed: " + rotSpeedY.ToString ());
			}
			break;
		default:
			rotSpeedY = 0;
			break;
		}
		Camera.main.transform.Rotate (-rotationSpeed * rotSpeedY, 0f, 0f, Space.Self);

		#region 
			/*if (Camera.main.transform.rotation.x <= 0.5f && Camera.main.transform.rotation.x >= -0.5f) {
				if (Input.mousePosition.y < (int)((screenHeight / 2) * (1 - multY)) || Input.mousePosition.y > (int)(screenHeight / 2) * (1 + multY)) {
					rotSpeedY = -1 + 2 * (Input.mousePosition.y / screenHeight);
					Camera.main.transform.Rotate (-rotationSpeed * rotSpeedY, 0f, 0f, Space.Self);
				}
			} else if (Camera.main.transform.rotation.x > 0.5f) {
				//print (Camera.main.transform.rotation);
				Camera.main.transform.Rotate((xRotation - 0.4f),0f,0f);
			} else if (Camera.main.transform.rotation.x < -0.5f) {
				Camera.main.transform.Rotate((xRotation + 0.4f),0f,0f);
			} 
			//else {
			//	Camera.main.transform.rotation = Quaternion.Euler(0f,0,0);
			//}
				/*
	        if (Input.GetKey(KeyCode.UpArrow) == true)
	        {
	            Camera.main.transform.Rotate(-rotationSpeed, 0f, 0f);
	        }
	        if (Input.GetKey(KeyCode.DownArrow) == true)
	        {
	            Camera.main.transform.Rotate(rotationSpeed, 0f, 0f);
	        }
	        if (Input.GetKey(KeyCode.RightArrow) == true)
	        {
	            Camera.main.transform.Rotate(0, rotationSpeed, 0f, Space.World);
	        }
	        if (Input.GetKey(KeyCode.LeftArrow) == true)
	        {
	            Camera.main.transform.Rotate(0, -rotationSpeed, 0f, Space.World);
	        }
	        */

        	//Camera.main.transform.Rotate(1f, 0f, 0f, Space.World);
		#endregion
    }
}
