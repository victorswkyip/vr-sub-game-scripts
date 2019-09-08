using UnityEngine;

public class DoorwayPanelController_Example : MonoBehaviour
{
	public DoorwayController_Example doorController;

	[Header("Panel")]
	public Renderer panelRenderer;
	public Color selectedColor;
	public Color normalColor;

	[Header("Keycard")]
	public Renderer keycardScreenRenderer;
	protected bool showingColor = false;
	protected float colorScreenTimerMax = 1.5f;
	protected float colorScreenTimer;

	[Header("Handle")]
	public Transform handle;
	public float handleOpenYPos;
	public float handleClosedYPos;
	protected bool doorOpen = false;

	void Update()
	{
		//If the keycard screen isn't black
		if (showingColor)
		{
			//If the countdown timer is complete
			if (colorScreenTimer <= 0)
			{
				//Set keycard screen back to black, and set flag for showing color to false
				showingColor = false;
				keycardScreenRenderer.material.color = Color.black;
			}
			else
			{
				//Count down the timer
				colorScreenTimer -= Time.deltaTime;
			}
		}
	}

	void Start()
	{
		//Set panel to normal color
		panelRenderer.material.color = normalColor;
	}

	//Player is looking at object
	public void OnFocused()
	{ 
		//Set panel to selected color on hover
        panelRenderer.material.color = selectedColor;
    }
	
	//Player stops looking at object
    public void OnDefocused()
	{
		//Set panel back to normal color when hover exits
        panelRenderer.material.color = normalColor;
    }

	//Player clicks on object
	public void OnClick()
	{
		//Toggle door open/closed - get error results
		bool error = doorController.ToggleDoorOpen();

		//If there is an error
		if (error)
		{
			//Change keypad color to red
			ChangeKeypadColor(Color.red);
		}
		else //There is no error
		{
			//Set handle position to open or closed position, depending on door open variable
			Vector3 position = handle.localPosition;
			position.y = doorOpen ? handleClosedYPos : handleOpenYPos;
			handle.localPosition = position;

			//Change Color to green
			ChangeKeypadColor(Color.green);

			//Toggle door open variable
			doorOpen = !doorOpen;
		}
	}

	protected void ChangeKeypadColor(Color color)
	{
		//Change keypad color, set timer, and set showingColor toggle to true.
		keycardScreenRenderer.material.color = color;
		colorScreenTimer = colorScreenTimerMax;
		showingColor = true;
	}
}
