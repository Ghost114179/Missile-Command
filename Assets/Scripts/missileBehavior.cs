using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class missileBehavior : MonoBehaviour
{
	

	float speed = 10f;
	//20f
	public GameObject target;
	public GameObject explosion;
	public GameObject smallExplosion;
	public GameObject smallExplosionSilent;
	float lastDestory;
	float destroyTimeout = 0.05f;
	//public List<GameObject> cities;
	public AudioSource downTonesource;
	// Use this for initialization

	void Start ()
	{
		getTarget ();
		alignToTarget ();
		downTonesource = GetComponent<AudioSource> ();
		switch (this.name) {
		case ("FastMissile(Clone)"):
			speed = 15f;
			break;
		case ("Missile(Clone)"):
			speed = 10f;
			break;
		case ("EMP(Clone)"):
			speed = 5f;
			break;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		transform.position += transform.forward * speed * Time.deltaTime;
		//if (not cities.Contains(target)) {
		//	getTarget();
		//	alignToTarget();
		//}
	}

	void alignToTarget ()
	{
		transform.LookAt (target.transform);
	}

	void getTarget ()
	{
		//print (this.name);
		if (this.name != "EMP(Clone)" && this.name != "EMP") {
			GameObject[] cities = GameObject.FindGameObjectsWithTag ("cityTurret");
			citiesRemaining.CitiesLeft = cities.Length;
			target = cities [Random.Range (0, cities.Length - 1)];
		} else {
			GameObject[] playerBuildings = GameObject.FindGameObjectsWithTag ("playerBuilding");
			target = playerBuildings [Random.Range (0, playerBuildings.Length - 1)];
		}
	}

	public void OnTriggerEnter (Collider collider)
	{
			
		if (Time.time > lastDestory + destroyTimeout && collider.gameObject.tag != "noCollide") {
			if (collider.gameObject.tag == "playerBuilding") {
				empExplosion.Shutdown = true;
				empExplosion.RebootTime = empExplosion.RestartTime;
			}
			//print (collider.gameObject.tag);
			if (collider.gameObject.tag == "cityTurret" || collider.gameObject.tag == "destroyedCity") {
				Instantiate (explosion, new Vector3 (transform.position.x - 25, transform.position.y + 40, transform.position.z), Quaternion.identity);
			} else if ((collider.gameObject.name == "playerShell") || (collider.gameObject.name == "playerShell(Clone)")) {
				//downTonesource.Play ();
				//Smaller Explosion
				Instantiate (smallExplosion, new Vector3 (transform.position.x - 25, transform.position.y + 40, transform.position.z), Quaternion.identity);
				//Increment "Saves" variable
				UIBehavior.Score += 1;
			} else {
				//Smaller Explosion
				Instantiate (smallExplosionSilent, new Vector3 (transform.position.x - 25, transform.position.y + 40, transform.position.z), Quaternion.identity);
			}
			//print(collider.gameObject.name);
			Destroy (this.gameObject);
			lastDestory = Time.time;
		}

	}

}
