using UnityEngine;
using System.Collections;

public class missileLauncherBehavior : MonoBehaviour {

    public Object missile;
	public Object FastMissile;
	public Object EMP;
    Vector3 newVector;
    Random randGenerator;
	float timeDelay = 1;//5;
    float timeSinceLastCreation;
    //float MapWidth = 500;
    //float MapHeight = 500;
	bool updateTimeDelay = true;
    int missileCount = 0;
    //int round = 1;

    public AudioSource creationSource;

    // Use this for initialization
    void Start () {
        creationSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		creationSource.volume = volumeBehavior.volumeLevel;
        if (Time.time >= timeSinceLastCreation + timeDelay)
        {
            fireMissile();
            creationSource.Play();
        }
	}

    void fireMissile()
    {
        missileCount += 1;
        timeSinceLastCreation = Time.time;
		if (updateTimeDelay) {
			applyTimeDelta(missileCount); //Lower time
		}
        float missileLocX = Random.Range(-250,250);
        float missileLocZ = Random.Range(-250,250);
        newVector = new Vector3(missileLocX, 350, missileLocZ);
		int RandomNumber = Random.Range (0, 9);
		//print (RandomNumber);
		if (RandomNumber <= 6) {
			GameObject newMissile = (GameObject)Instantiate (missile, newVector, transform.rotation);
		} else if (RandomNumber <= 8) {
			GameObject newEMP = (GameObject)Instantiate (EMP, newVector, transform.rotation);
		} else {
			GameObject newFastMissile = (GameObject)Instantiate (FastMissile, newVector, transform.rotation);
		}
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
