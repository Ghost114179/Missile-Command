﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class beginScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return)) {
			SceneManager.LoadScene ("level1");
		}
	}
}
