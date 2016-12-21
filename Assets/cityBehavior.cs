using UnityEngine;
using System.Collections;

public class cityBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Delay()
	{
		yield return new WaitForSeconds(0.9f);
		Destroy(this.gameObject);
	}

	public void OnTriggerEnter(Collider collider)
	{
		if (collider.name != "playerShell(Clone)") {
			gameObject.tag = "destroyedCity";
			StartCoroutine ("Delay");
		}

	}
}
