using UnityEngine;
using System.Collections;

public class audioBehavior : MonoBehaviour {

    AudioSource shootSource;
	// Use this for initialization
	void Start () {
        shootSource = GetComponent<AudioSource>();
	}

	public void shootSound() {
		shootSource.volume = volumeBehavior.volumeLevel;
		shootSource.Play ();
	}
}
