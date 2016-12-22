using UnityEngine;
using System.Collections;

public class missileLauncherBehavior : MonoBehaviour {

    Object missile;
    Vector3 newVector;
    Random randGenerator;
    float timeDelay = 5;
    float timeSinceLastCreation;
    //float MapWidth = 500;
    //float MapHeight = 500;
	bool updateTimeDelay = true;
    int missileCount = 0;
    //int round = 1;

    AudioSource creationSource;

    // Use this for initialization
    void Start () {
        missile = Resources.Load("Missile");
        fireMissile();

        creationSource = GetComponent<AudioSource>();
        creationSource.Play();

    }
	
	// Update is called once per frame
	void Update () {
        
        if (Time.time >= timeSinceLastCreation + timeDelay)
        {
			//print ("DELAYED_TIME: " + (float)(timeSinceLastCreation + timeDelay));
			//print ("TIME: " + Time.time);
            fireMissile();
            creationSource.Play();
        }
	}

    void fireMissile()
    {
       // creationSource.Play();
        missileCount += 1;
        timeSinceLastCreation = Time.time;
		if (updateTimeDelay) {
			applyTimeDelta(missileCount); //Lower time
		}
        float missileLocX = Random.Range(-250,250);
        float missileLocZ = Random.Range(-250,250);
        newVector = new Vector3(missileLocX, 350, missileLocZ);
        GameObject newMissile = (GameObject)Instantiate(missile, newVector, transform.rotation);
        
    }

    void applyTimeDelta(int missilesShot)
    {
		float logBase = (float)(1+(1.3/Mathf.Exp(1)));
		float log = (float)((missileCount + 5) / 5);
		timeDelay = 10f - Mathf.Log(log, logBase);
		if (timeDelay < 0.25f) {
			timeDelay = 0.25f;
			updateTimeDelay = false;
		}
		//print(timeDelay);
    }
}
