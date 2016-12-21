using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class citiesRemaining : MonoBehaviour {
	Text Cities;
	public static int CitiesLeft;
	// Use this for initialization
	void Start () {
		Cities = GetComponent<Text> ();
		CitiesLeft = 6;
	}
	
	// Update is called once per frame
	void Update () {
		Cities.text = ("Cities Remaining: " + CitiesLeft.ToString ()).ToString ();
	}
}
