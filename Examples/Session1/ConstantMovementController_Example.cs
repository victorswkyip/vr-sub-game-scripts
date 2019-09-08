using UnityEngine;

public class ConstantMovementController_Example : MonoBehaviour
{
	public bool constantMovementEnabled = false;
	public Transform cameraTransform;
	public bool yLock = true;
	public float speed = 1;

	void Update()
	{
		if (constantMovementEnabled)
		{
			//Get position along forward vector at speed
			Vector3 newPosition = transform.position + cameraTransform.forward * speed * Time.deltaTime;

			//SKeep Y position if y should stay locked
			if (yLock)
			{
				newPosition.y = transform.position.y;
			}

			//Apply
			transform.position = newPosition;
		}
	}
}





