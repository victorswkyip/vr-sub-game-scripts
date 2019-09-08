using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineController : MonoBehaviour
{
	
	public float speed, rotationspeed;
	public Transform headDirection = null;
	public Transform headRotation = null;
	public Transform firingPoint;
	public GameObject torpedoPrefab;

	private bool isAlive = true;

	// Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	void Update ()
	{
		if (isAlive) {
			this.transform.position += headDirection.forward * speed * Time.deltaTime;
			headRotation.rotation = Quaternion.Slerp (headRotation.rotation, headDirection.rotation, Time.deltaTime * rotationspeed);

			if (GvrViewer.Instance.Triggered) {
				FireTorpedo ();
			}
		} 
	}
	public void KillSub() {
		isAlive = false;
		UIHelper_Example.ChangeText ("YOU DEAD");
	}
	private void FireTorpedo(){
		Instantiate (torpedoPrefab,firingPoint.position, firingPoint.rotation);

	}

}
