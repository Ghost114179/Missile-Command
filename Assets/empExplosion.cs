using UnityEngine;
using System.Collections;

public class empExplosion : MonoBehaviour {
	public static bool Shutdown = false;
	public static float RebootTime;
	public static float RestartTime = 25f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//print (Shutdown);
		if (RebootTime > 0) {
			RebootTime -= Time.deltaTime;
		}
		if (RebootTime <= 0) {
			Shutdown = false;
			RebootTime = 0;
		}
	}

	public void OnTriggerEnter(Collider collider) {
		//print (collider.gameObject.name);
		if (collider.gameObject.name == "EMP(Clone)") {
			Shutdown = true;
			RebootTime = RestartTime;
		}
	}
}
