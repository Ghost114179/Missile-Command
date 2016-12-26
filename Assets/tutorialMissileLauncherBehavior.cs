using UnityEngine;
using System.Collections;

public class tutorialMissileLauncherBehavior : MonoBehaviour {

	public AudioSource creationSource;
	public Object missile;
	public Object FastMissile;
	public Object EMP;
	Vector3 newVector;

	// Use this for initialization
	void Start () {
		creationSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		creationSource.volume = volumeBehavior.volumeLevel;
		if (Input.GetKeyUp(KeyCode.Return))
		{
			fireMissile();
			creationSource.Play();
		}
	}

	void fireMissile()
	{
		float missileLocX = Random.Range(-250,250);
		float missileLocZ = Random.Range(-250,250);
		newVector = new Vector3(missileLocX, 350, missileLocZ);
		int RandomNumber = Random.Range (0, 10);
		//print (RandomNumber);
		if (RandomNumber <= 6) {
			GameObject newMissile = (GameObject)Instantiate (missile, newVector, transform.rotation);
		} else if (RandomNumber <= 8) {
			GameObject newEMP = (GameObject)Instantiate (EMP, newVector, transform.rotation);
		} else {
			GameObject newFastMissile = (GameObject)Instantiate (FastMissile, newVector, transform.rotation);
		}
	}
}
