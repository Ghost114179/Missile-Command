using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {
	public static bool paused;
	public Canvas pauseCanvas;
	public Canvas pauseHUD;
	// Use this for initialization

	void Start () {
		pauseCanvas.enabled = false;
		pauseHUD.enabled = true;
		Time.timeScale = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Escape)) {
			if (pauseCanvas.enabled == false) {
				Time.timeScale = 0f; //pause time
				pauseCanvas.enabled = true;
				pauseHUD.enabled = false;
			} else {
				Time.timeScale = 1.0f;
				pauseCanvas.enabled = false;
				pauseHUD.enabled = true;
			}
			paused = !paused;
		}
	}
}
