using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pauseManager : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		this.GetComponentInChildren<deadZone>().enabled = true;
		this.GetComponentInChildren<delayBar>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameManager.paused) {
			this.GetComponentInChildren<deadZone> ().enabled = false;
			this.GetComponentInChildren<delayBar>().enabled = false;
		} else {
			this.GetComponentInChildren<deadZone>().enabled = true;
			this.GetComponentInChildren<delayBar>().enabled = true;
		}
	}
}
