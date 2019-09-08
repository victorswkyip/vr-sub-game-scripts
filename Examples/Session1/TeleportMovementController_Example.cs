using UnityEngine;

public class TeleportMovementController_Example : MonoBehaviour
{
	public bool teleportEnabled = false;

	public void TeleportToPosition(Vector3 targetPosition)
	{
		if (teleportEnabled)
		{
			//Pull x and z from target, but keep y ("head height");
			transform.position = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
		}
	}
}
