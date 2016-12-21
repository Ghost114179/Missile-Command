using UnityEngine;
using System.Collections;

public class pauseManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponentInChildren<deadZone> ().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameManager.paused) {
			this.GetComponentInChildren<deadZone> ().enabled = false;
		} else {
			this.GetComponentInChildren<deadZone> ().enabled = true;
		}
	}
}
