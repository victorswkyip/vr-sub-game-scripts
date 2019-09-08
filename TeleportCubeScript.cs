using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCubeScript : MonoBehaviour
{
	
	private bool teleportFlag = false;

	private Vector3 startingPosition;

	void Start(){
		startingPosition = this.transform.position;
	}

	public void TeleportwithDistance (float teleportDistance){
		TeleportGivenDistance (teleportDistance);
	}

	public void TeleportRandomDistance(){
		TeleportGivenDistance (Random.Range (0f, 5f));
	}

	private void TeleportGivenDistance(float newDistance){
		if (!teleportFlag) {
			this.transform.position = startingPosition + new Vector3 (0f, 0f, newDistance);
		} else {
			this.transform.position = startingPosition;
		}
		teleportFlag = !teleportFlag;
	}

}

