using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDBehavior : MonoBehaviour {

    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Missiles Destroyed:" + UIBehavior.Score.ToString();
	}
}
