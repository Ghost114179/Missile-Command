using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class deadZoneBehavior : MonoBehaviour {
	public Slider DeadZoneSlider;

	float lastUpdate = 0f;
	float updateDelay = 0.25f;

	// Use this for initialization
	void Start () {
		DeadZoneSlider.value = 0.3f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > lastUpdate + updateDelay) {
			cameraRotationScript.multX = DeadZoneSlider.value;
			cameraRotationScript.multY = DeadZoneSlider.value;
			lastUpdate = Time.time;
		}
	}
}
