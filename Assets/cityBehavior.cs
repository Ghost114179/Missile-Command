using UnityEngine;
using System.Collections;

public class cityBehavior : MonoBehaviour {
	public MeshRenderer FutureCityMesh;
	public MeshRenderer RuralTownMesh;
	public MeshRenderer ModernCityMesh;

	// Use this for initialization
	void Start () {
		FutureCityMesh.enabled = false;
		RuralTownMesh.enabled = false;
		ModernCityMesh.enabled = false;
		switch (Random.Range (0, 3)) {
		case 0:
			//print ("Future");
			FutureCityMesh.enabled = true;
			break;
		case 1:
			//print ("Rural");
			RuralTownMesh.enabled = true;
			break;
		case 2:
			//print ("Modern");
			ModernCityMesh.enabled = true;
			break;
		default:
			//print ("Default");
			FutureCityMesh.enabled = true;
			break;
		}
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
