using UnityEngine;

using System.Collections;

public class cameraRotationScript : MonoBehaviour {

	public static float rotationSpeed = 0.5f;
    float rotSpeedX;
    float rotSpeedY;
	public static float multX = 0.3f;
	public static float multY = 0.3f;
	int screenWidth = Screen.width;
	int screenHeight = Screen.height;
	float xRotation;
	int State = 0;
	public static int activeTurretID = 0;
	Quaternion currentRotation;

	// Use this for initialization
	void Start () {
	}

	int getState() {
		xRotation = transform.localEulerAngles[0];
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

	int getTurretID() {
		int turretControl = 0;
		currentRotation = Camera.main.transform.localRotation;
		if (currentRotation.eulerAngles.y >= 0 && currentRotation.eulerAngles.y < 120) {
			turretControl = 1;
		} else if (currentRotation.eulerAngles.y >= 120 && currentRotation.eulerAngles.y < 240) {
			turretControl = 2;
		} else if (currentRotation.eulerAngles.y >= 240 && currentRotation.eulerAngles.y <= 360) {
			turretControl = 3;
		}
		return turretControl;
	}

	// Update is called once per frame
	void Update () {
		if (!gameManager.paused) {
			activeTurretID = getTurretID ();
			rotSpeedY = 0;
			if (Input.mousePosition.x < (int)((screenWidth / 2) * (1 - multX)) || Input.mousePosition.x > (int)((screenWidth / 2) * (1 + multX))) {
				rotSpeedX = -1 + 2 * (Input.mousePosition.x / screenWidth);
				Camera.main.transform.Rotate (0f, rotationSpeed * rotSpeedX, 0f, Space.World);
			}

			State = getState ();
			switch (State) {
			case (0):
				if (Input.mousePosition.y < (int)((screenHeight / 2) * (1 - multY)) || Input.mousePosition.y > (int)((screenHeight / 2) * (1 + multY))) {
					rotSpeedY = -1 + 2 * (Input.mousePosition.y / screenHeight);
				}
				break;
			case (2):
				if (Input.mousePosition.y > (int)(screenHeight / 2) * (1 + multY)) {
					rotSpeedY = -1 + 2 * (Input.mousePosition.y / screenHeight);
				}
				break;
			case (1):
				if (Input.mousePosition.y < (int)((screenHeight / 2) * (1 - multY))) {
					rotSpeedY = -1 + 2 * (Input.mousePosition.y / screenHeight);
				}
				break;
			default:
				rotSpeedY = 0;
				break;
			}
			Camera.main.transform.Rotate (-rotationSpeed * rotSpeedY, 0f, 0f, Space.Self);

		}
    }
}
