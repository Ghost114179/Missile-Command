using UnityEngine;
using System.Collections;

public class shellBehavior : MonoBehaviour {

	float speed = 150f;//150f;
    float timeAtCreation;
    float lifetime = 3; //30 seconds till deletion
	public bool updateDirection = false;
	public GameObject targetMissile;

	// Use this for initialization
	void Start () {
        timeAtCreation = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        //print(timeAtCreation);
		//print(updateDirection);
		if (updateDirection) {
			this.transform.LookAt(targetMissile.transform);
		}
        transform.position += transform.forward * speed * Time.deltaTime;
        if (Time.time > timeAtCreation + lifetime) //kill instance
        {
            Destroy(this.gameObject);
        }

    }

    public void OnTriggerEnter(Collider collider)
    {
		if (collider.gameObject.tag != "NoCollide") {
			//print("Killed By: " + collider.gameObject.tag);
			Destroy (this.gameObject);
		}
    }
}
