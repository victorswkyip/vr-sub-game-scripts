using UnityEngine;

public class SimpleWaypointController_Example : MonoBehaviour
{
	public Color selectedColor;
	public Color normalColor;

	protected TeleportMovementController_Example playerTeleportController;
	protected Renderer waypointRenderer;

	void Awake()
	{
		//Find the Player, and if found, get the Waypoint Controller
		//There are better ways to accomplish this, but this is probably the simplest
		GameObject player = GameObject.FindWithTag("Player");
		if (player != null)
		{
			playerTeleportController = player.GetComponent<TeleportMovementController_Example>();
		}

		waypointRenderer = GetComponent<Renderer>();
	}
	
	public void Select()
	{
		//Change the waypoint pieces to their Selected color
		waypointRenderer.GetComponent<Renderer>().material.color = selectedColor;
	}
	
	public void Deseslect()
	{
		//Change the waypoint pieces to their Normal color
		waypointRenderer.GetComponent<Renderer>().material.color = normalColor;
	}

	public void TeleportPlayer()
	{
		//Call teleport function on player teleport controller
		if (playerTeleportController != null)
		{
			playerTeleportController.TeleportToPosition(transform.position);
		}
	}
}
