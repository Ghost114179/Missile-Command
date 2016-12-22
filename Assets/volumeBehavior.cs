using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class volumeBehavior : MonoBehaviour {
	public static float volumeLevel;
	public Slider volumeSlider;

	float lastUpdate = 0f;
	float updateDelay = 0.25f;

	// Use this for initialization
	void Start () {
		volumeSlider.value = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > lastUpdate + updateDelay) {
			volumeLevel = volumeSlider.value;
			lastUpdate = Time.time;
		}
	}
}
