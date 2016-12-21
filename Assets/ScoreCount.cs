using UnityEngine;
using System.Collections;

public class ScoreCount : MonoBehaviour {
    // Use this for initialization
    TextMesh mesh;
	void Start () {
        
        mesh = GetComponent<TextMesh>();
		//print("Score: " + UIBehavior.Score);
        mesh.text = UIBehavior.Score.ToString();
    


    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit ();
		}
	}

}
