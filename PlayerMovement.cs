using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	//public GameObject otherObject;

	public float speed;
	public Transform currentDirection = null;

	// Update is called once per frame
	void Update ()
	{
		this.transform.position = this.transform.position + currentDirection.forward * speed * Time.deltaTime;
		//this.transform.position = this.transform.position + (new Vector3 (currentDirection.forward.x, 0, currentDirection.forward.z)) * speed * Time.deltaTime;
	}
}
