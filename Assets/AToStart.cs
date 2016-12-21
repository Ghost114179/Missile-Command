using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AToStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKeyDown(KeyCode.A)) //If A Is pressed,
        {
            //Load Game!
            SceneManager.LoadScene("instructionMenu");
        }
	}
}
