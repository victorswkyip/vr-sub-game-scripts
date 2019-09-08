using UnityEngine;

public class WaypointController_Example : MonoBehaviour
{
	//Waypoint Visuals
	public Transform waypointPyramid;
	public Transform waypointBorder;

	//Colors
	public Color selectedColor;
	public Color normalColor;

	//Rotation Variables
	public float rotateSpeed = 120f;
	protected float rotationAmount = 0;

	//Other
	protected PlayerController_Example playerController;
	protected bool isSelected;

	void Awake()
	{
		//Find the Player, and if found, get the Waypoint Controller
		//There are better ways to accomplish this, but this is probably the simplest
		GameObject player = GameObject.FindWithTag("Player");
		if (player != null)
		{
			playerController = player.GetComponent<PlayerController_Example>();
		}
	}

	void Start ()
	{
        //Make sure the waypoints are all starting "deselected"
        OnDefocused();
    }

    void Update()
	{
		//Function that handles the waypoint spinning
        WaypointSpin();
    }

	//Player is looking at object
	public void OnFocused()
	{
		isSelected = true;

		//Change waypoit color to selected color
		waypointBorder.GetComponent<Renderer>().material.color = selectedColor;
		waypointPyramid.GetComponent<Renderer>().material.color = selectedColor;
	}

	//Player has looked away from object
    public void OnDefocused()
	{
		isSelected = false;

		//Change waypoint color to normal color
		waypointBorder.GetComponent<Renderer>().material.color = normalColor;
		waypointPyramid.GetComponent<Renderer>().material.color = normalColor;
	}

	protected void WaypointSpin()
	{
		if (isSelected)
		{
			//Rotate waypoint
			rotationAmount += Time.deltaTime * rotateSpeed;
			waypointPyramid.rotation = Quaternion.Euler(0, rotationAmount, 0);
			waypointBorder.rotation = Quaternion.Euler(0, -rotationAmount, 0);
		}
	}

	public void TeleportPlayer()
	{
		//Call teleport function on player controller
		if (playerController != null)
		{
			playerController.TeleportToPosition(transform.position);
		}
	}
}
