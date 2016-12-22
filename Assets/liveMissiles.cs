using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class liveMissiles : MonoBehaviour {
	Text Missiles;

	// Use this for initialization
	void Start () {
		Missiles = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] missiles = GameObject.FindGameObjectsWithTag("Missile");
		Missiles.text = ("Live Missiles:\n" + missiles.Length).ToString ();
	}
}
