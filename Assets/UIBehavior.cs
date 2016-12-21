using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIBehavior : MonoBehaviour {
	public static int Score;
	Text scoreText;
	// Use this for initialization
	void Start () {
		UIBehavior.Score = 0;
		scoreText = GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		scoreText.text = "Missiles Destroyed: " + UIBehavior.Score.ToString ();
			
	}
}
