using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class citiesRemaining : MonoBehaviour {
	Text Cities;
	public static int CitiesLeft;
	int livesLeft;
	// Use this for initialization
	void Start () {
		Cities = GetComponent<Text> ();
		CitiesLeft = 6;
	}
	
	// Update is called once per frame
	void Update () {
		livesLeft = CitiesLeft - difficultyBehavior.Difficulty + 1;
		Cities.text = "Cities Remaining:\n" + livesLeft.ToString ();
	}
}
