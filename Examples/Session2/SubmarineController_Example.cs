using UnityEngine;

public class SubmarineController_Example : MonoBehaviour
{
	public static bool alive = true;

	public Transform cameraTransform;
	public Transform submarineHolder;
	public Transform fireSpot;
	public float speed = 5;
	public float rotationSpeed = 5;

	public GameObject missilePrefab;

	void Update()
	{
		if (alive)
		{
			//Get position along forward vector at speed
			transform.position += cameraTransform.forward * speed * Time.deltaTime;

			//Apply camera's rotation to submarine
			Quaternion cameraRotation = cameraTransform.rotation;
			Quaternion submarineRotation = submarineHolder.rotation;
			submarineHolder.rotation = Quaternion.Slerp(submarineRotation, cameraRotation, Time.deltaTime * rotationSpeed);

			//If Button Pressed
			if (GvrViewer.Instance.Triggered)
			{
				//Fire a missile
				Instantiate(missilePrefab, fireSpot.position, fireSpot.rotation);
			}
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		alive = false;

		//Update UI Message
		UIHelper_Example.ChangeText("You Lose!");
	}
}
