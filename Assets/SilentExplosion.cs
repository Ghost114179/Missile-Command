using UnityEngine;
using System.Collections;

public class SilentExplosion : MonoBehaviour {

	float scaleFactor = 0.5f;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (transform.localScale.x < 10f)
		{
			transform.localScale = new Vector3(transform.localScale.x + scaleFactor, transform.localScale.y + scaleFactor, transform.localScale.z + scaleFactor);

		}
		else
		{
			Destroy(this.gameObject);
		}
	}
}
