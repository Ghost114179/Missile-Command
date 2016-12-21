using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class difficultyBehavior : MonoBehaviour {
	public static int Difficulty = 1;
	Text difficultyLevel;

	// Use this for initialization
	void Start () {
		difficultyLevel = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("up") && Difficulty < 6) {
			Difficulty += 1;
		}
		if (Input.GetKeyDown("down") && Difficulty > 1) {
			Difficulty -= 1;
		}
		difficultyLevel.text = ("Use Arrow Keys To Adjust \nDifficulty (Cities): " + Difficulty + " \nPress Enter When Finished").ToString ();
	}
}
