using UnityEngine;
using System.Collections;

public class delayBar : MonoBehaviour {
	public float barDisplay;
	public Vector2 pos = new Vector2(275,1250);
	public Vector2 size = new Vector2(4000,30);
	public Texture2D emptyTexture;
	public Texture2D filledTexture;
	float tempDisplay;

	void OnGUI() {
		//GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
		GUI.DrawTexture(new Rect(pos.x,pos.y, size.x, size.y), emptyTexture, ScaleMode.StretchToFill);
		GUI.DrawTexture(new Rect(pos.x,pos.y, size.x * barDisplay, size.y), filledTexture, ScaleMode.StretchToFill);
	}

	void Update() {
		tempDisplay = ((Time.time - fireBehavior.lastFire) / (fireBehavior.fireDelay));
		if (tempDisplay < 1.0f) {
			barDisplay = tempDisplay;
		} else {
			barDisplay = 1.0f;
		}
	}
}