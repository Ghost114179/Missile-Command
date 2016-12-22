using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class spreadBehavior : MonoBehaviour {
	Text weaponText;
	float scrollDelta;
	float newSpread;
	string status = "Deactivated";
	// Use this for initialization
	void Start () {
		weaponText = GetComponent<Text> ();
		updateText ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Z)) {
			fireBehavior.shotType = fireBehavior.shotType - 1;
			if (fireBehavior.shotType <= -1) {
				fireBehavior.shotType = 2;
			}
		}
		if (Input.GetKeyUp(KeyCode.X)) {
			fireBehavior.shotType = fireBehavior.shotType + 1;
			if (fireBehavior.shotType >= 3) {
				fireBehavior.shotType = 0;
			}
		}
		switch (fireBehavior.shotType) {
			case 1:
				status = "Shatter Round";
				break;

			case 2:
				status = "Self-Guided\nRound";
				break;
			
			default:
				status = "Regular Round";
				break;
		}
		updateText();
		scrollDelta = Input.mouseScrollDelta[1];
		if (scrollDelta != 0f) {
			newSpread = fireBehavior.spreadMult + (scrollDelta * Time.deltaTime);
			if (newSpread > 0.5f && newSpread < 20.0f) {
				fireBehavior.spreadMult = newSpread;
			} else if (newSpread > 20.0f) {
				fireBehavior.spreadMult = 20.0f;
			} else if (newSpread < 0.5f) {
				fireBehavior.spreadMult = 0.5f;
			} else {
				fireBehavior.spreadMult = 1f;
			}
			updateText ();
		}
	}

	void updateText() {
		if (fireBehavior.shotType != 1) {
			weaponText.text = status;
		} else {
			weaponText.text = (status + "\nSpread Value: " + Math.Round (fireBehavior.spreadMult, 1)).ToString ();
		}
	}
}
