using UnityEngine;
using System.Collections;

public class deadZone : MonoBehaviour {
	public Texture2D zoneTexture;
	float widthMultiplier = cameraRotationScript.multX;
	float heightMultiplier = cameraRotationScript.multY;
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
				((int)(screenWidth*(0.5-(0.5*widthMultiplier)))),
				((int)(screenHeight*(0.5-(0.5*heightMultiplier)))),
				((int)(screenWidth*widthMultiplier)),
				((int)(screenHeight*heightMultiplier))
			),
			zoneTexture
		);
	}
}