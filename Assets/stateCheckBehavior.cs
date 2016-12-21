using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class stateCheckBehavior : MonoBehaviour {

    // Use this for initialization
    float timeSinceLastCheck;
    float checkInterval = 2;
	void Start () {
        timeSinceLastCheck = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			SceneManager.LoadScene ("gameOver");
		}
        if(Time.time >= timeSinceLastCheck + checkInterval)
        {
            GameObject[] cities = GameObject.FindGameObjectsWithTag("cityTurret");
			if (cities.Length < difficultyBehavior.Difficulty)
            {
                //Load "GAME OVER" screen.
                SceneManager.LoadScene("gameOver");
            }
            timeSinceLastCheck = Time.time;
        }
       
    }
}
