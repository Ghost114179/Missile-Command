using UnityEngine;
using System.Collections;

public class deadZone : MonoBehaviour {
	public Texture2D zoneTexture;
	int screenWidth = Screen.width;
	int screenHeight = Screen.height;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI() {
		GUI.DrawTexture(
			new Rect(
				((int)(screenWidth*(0.5-(0.5*cameraRotationScript.multX)))),
				((int)(screenHeight*(0.5-(0.5*cameraRotationScript.multY)))),
				((int)(screenWidth*cameraRotationScript.multX)),
				((int)(screenHeight*cameraRotationScript.multY))
			),
			zoneTexture
		);
	}

}