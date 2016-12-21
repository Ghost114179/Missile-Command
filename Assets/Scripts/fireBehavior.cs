﻿using UnityEngine;
using System.Collections;
using System;

public class fireBehavior : MonoBehaviour {
	
	UnityEngine.Object bullet;
	vrBehavior referenceFile;
	public int turretID;
	public static float lastFire;
	public static float fireDelay = 0.25f;  //Tune this to what delay between shots should be
	public static int shotType = 0;
	float[,] defaultSpread = {{1f,-1f},{1f,0f},{1f,1f},{0f,-1f},{0f,0f},{0f,1f},{-1f,-1f},{-1f,0f},{-1f,1f}};
	//audioBehavior sS = Command_Tower.GetComponent<audioBehavior>().shootSound();
	public audioBehavior target;
	public static float spreadMult = 1.0f;
	public shellBehavior Shot;
	float minAccuracyAngle = 15f;

	float regularDelay = 0.2f;
	float shatterDelay = 3.0f;
	float guidedDelay = 6.0f;

	// Use this for initialization
	void Start () {
		bullet = Resources.Load("playerShell");
		referenceFile = new vrBehavior();
	}

	// Update is called once per frame
	void Update () {
		referenceFile.Update();
		#region firing
		if (referenceFile.turretControl == turretID)
		{
			if (Input.GetKey(KeyCode.Space))
			{
				fireShot(); //Fire a shell!
			}
		}

		#endregion
	}

	void fireShot()
	{
		if (Time.time > lastFire + fireDelay) {
			switch (shotType) {
			case 1: //Shatter
				float[] adjustment = { 0f, 0f, 0f };
				for (int shotNum = 0; shotNum <= 8; shotNum += 1) {
					for (int i = 0; i <= 1; i += 1) {
						adjustment [i] = defaultSpread [shotNum, i] * spreadMult;
					}
					GameObject newRound = (GameObject)Instantiate (bullet, transform.position, transform.rotation);
					//print("Pre-Fired: " + shotNum.ToString() + " Rotation: " + newRound.transform.localRotation);
					newRound.transform.Rotate (adjustment [1], adjustment [0], 0, Space.Self);
					//print("Fired: " + shotNum.ToString() + " Rotation: " + newRound.transform.localRotation);
				}
				fireDelay = shatterDelay;
				break;
			case 2: //Self Guided
				GameObject targetMissile = getClosestMissile ();
				if (targetMissile != null) {
					GameObject newGuided = (GameObject)Instantiate (bullet, transform.position, transform.rotation);
					newGuided.transform.LookAt (targetMissile.transform);
					Shot = newGuided.GetComponent<shellBehavior> ();
					Shot.updateDirection = true;
					Shot.targetMissile = targetMissile;
					fireDelay = guidedDelay;
				} else {
					GameObject newRegular = (GameObject)Instantiate (bullet, transform.position, transform.rotation);
					fireDelay = guidedDelay;
				}
				break;

			default: //Regular
				GameObject newRegular = (GameObject)Instantiate (bullet, transform.position, transform.rotation);
				fireDelay = regularDelay;
				break;
			}

			lastFire = Time.time;
			target.shootSound();
		}
	}

	GameObject getClosestMissile() {
		float heading;
		Vector3 Direction;
		GameObject[] missiles = GameObject.FindGameObjectsWithTag ("Missile");
		GameObject ClosestMissile = null;
		float smallestDirection = minAccuracyAngle;
		float sumDirection;
		float distance;
		for (int i = 0; i <= (missiles.Length - 1); i++) {
			heading = Vector3.Angle(missiles[i].transform.position, this.gameObject.transform.forward);
			distance = Vector3.Distance(missiles[i].transform.position, this.gameObject.transform.forward);
			//print ("Direction: " + heading);
			if (heading < smallestDirection) {
				ClosestMissile = missiles[i];
				smallestDirection = heading;
			}
		}
		return ClosestMissile;
	}
}