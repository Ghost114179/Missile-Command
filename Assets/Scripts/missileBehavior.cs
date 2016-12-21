using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class missileBehavior : MonoBehaviour {


    float speed = 10f; //20f
    public GameObject target;
    public GameObject explosion;
    public GameObject smallExplosion;
	float lastDestory;
	float destroyTimeout = 0.05f;
	//public List<GameObject> cities;
    public AudioSource downTonesource;
	// Use this for initialization

	void Start () {
		//print (Scores.Score);
        getTarget();
        alignToTarget();
        explosion = (GameObject)Resources.Load("NukeExplosion");
        smallExplosion = (GameObject)Resources.Load("MissileExplosion");
        downTonesource = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update () {
        transform.position += transform.forward * speed * Time.deltaTime;
		//if (not cities.Contains(target)) {
		//	getTarget();
		//	alignToTarget();
		//}
    }

    void alignToTarget()
    {
        transform.LookAt(target.transform);
    }

    void getTarget()
    {
		GameObject[] cities = GameObject.FindGameObjectsWithTag("cityTurret");
		citiesRemaining.CitiesLeft = cities.Length;
		target = cities[Random.Range(0, cities.Length - 1)];
    }

    public void OnTriggerEnter(Collider collider)
    {
		if (Time.time > lastDestory + destroyTimeout) {
			if (collider.gameObject.tag == "cityTurret") {
				Instantiate (explosion, new Vector3 (transform.position.x - 25, transform.position.y + 40, transform.position.z), Quaternion.identity);
			} else if ((collider.gameObject.name == "playerShell") || (collider.gameObject.name == "playerShell(Clone)")) {
				downTonesource.Play ();
				//Smaller Explosion
				Instantiate (smallExplosion, new Vector3 (transform.position.x - 25, transform.position.y + 40, transform.position.z), Quaternion.identity);
				//Increment "Saves" variable
				UIBehavior.Score += 1;
			} else {
				downTonesource.Play ();
				//Smaller Explosion
				Instantiate (smallExplosion, new Vector3 (transform.position.x - 25, transform.position.y + 40, transform.position.z), Quaternion.identity);
			}
			//print(collider.gameObject.name);
			Destroy (this.gameObject);
			lastDestory = Time.time;
		}

    }

}
