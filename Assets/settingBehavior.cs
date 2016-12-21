using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class settingBehavior : MonoBehaviour {
	Text lookSensitivityText;
	float sliderValue = 0.5f;
	public Slider Sensitivity;
	string displayText = "Look Sensitivity: ";
	public static int displaySliderValue;

	float lastUpdate = 0f;
	float updateDelay = 0.5f;

	// Use this for initialization
	void Start () {
		lookSensitivityText = GetComponent<Text> ();
		Sensitivity.value = 0.5f;
	}
	// Update is called once per frame
	void Update () {
		sliderValue = Sensitivity.value;
		displaySliderValue = (int)(sliderValue * 100);

		lookSensitivityText.text = displayText + displaySliderValue;
		if (Time.time > lastUpdate + updateDelay) {
			cameraRotationScript.rotationSpeed = sliderValue;
			lastUpdate = Time.time;
		}
	}

}
