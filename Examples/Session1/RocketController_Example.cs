using UnityEngine;

public class RocketController_Example : MonoBehaviour
{
	public Rigidbody objRigidBody;
	public float verticalForce = 1f;

	protected Vector3 startLocation;
	protected Quaternion startRotation;

	void Awake()
	{
		//Set initial locations
		startLocation = transform.position;
		startRotation = transform.rotation;
	}

	public void LaunchRocket()
	{
		//Add vertical force to the rigidbody, launching it
		if (objRigidBody != null)
		{
			objRigidBody.AddForce(new Vector3(0, verticalForce * 1000, 0));
		}
	}

	public void ResetRocket()
	{
		//Reset to original position
		transform.position = startLocation;
		transform.rotation = startRotation;

		//Zero out any remaining velocity
		if (objRigidBody != null)
		{
			objRigidBody.velocity = Vector3.zero;
		}
	}
}
