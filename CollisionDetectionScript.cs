using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionScript : MonoBehaviour {

	//public SubmarineController submarineControllerBase;

	void OnTriggerEnter(Collider thingIHit){
		Debug.Log ("Ouch I hit something");
		//submarineControllerBase.KillSub();
		this.transform.root.GetComponent<SubmarineController> ().KillSub ();

	}
}
