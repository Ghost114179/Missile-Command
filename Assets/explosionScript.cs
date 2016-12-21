using UnityEngine;
using System.Collections;

public class explosionScript : MonoBehaviour {

    float scaleFactor = 0.5f;
    AudioSource source;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        source.Play();
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.localScale.x < 10f)
        {
            transform.localScale = new Vector3(transform.localScale.x + scaleFactor, transform.localScale.y + scaleFactor, transform.localScale.z + scaleFactor);
            
        }
        else
        {
            Destroy(this.gameObject);
        }
        
        
       
        
    }
}
