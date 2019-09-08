using UnityEngine;
using UnityEngine.VR;

public class PlayerController_Example : MonoBehaviour
{
	public bool moveWithDashing = true;
	public Renderer fadePlaneRenderer;

	//Movement / Teleporting variables
	protected Vector3 startPosition;
	protected Vector3 endPosition;
	protected bool isPlayerMoving;

	//Fading
	protected float fadeOutPercentage = 0;
	protected float fadeInPercentage = 0;

	//Dashing
	protected float movementPercentage = 0;
	protected float dashingSpeed = 5;

	void Start()
	{
		//We want to recenter our view each time we start the game. 
		//Whatever direction on the X/Z plane the headset is pointed when the game is started will be "Forward"
        UnityEngine.XR.InputTracking.Recenter();
    }

	void Update()
	{
        //If the player should be moving, we want to process that movement each frame 
        if (isPlayerMoving)
		{
            if (moveWithDashing)
			{
                //Dashing
                HandlePlayerMovementDashing();
            }
            else
			{
                //Fading
                HandlePlayerMovementFading();
            }
        }
    }

	public void TeleportToPosition(Vector3 targetPosition)
	{
		//Pull x and z from target, but keep y ("head height");
		Vector3 position = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
		startPosition = transform.position;
		endPosition = position;
		isPlayerMoving = true;
	}

	protected void HandlePlayerMovementFading()
	{
        if (fadeOutPercentage < 1)
		{
			//Fade Out
			fadePlaneRenderer.material.color = Color.Lerp(Color.clear, Color.black, fadeOutPercentage);
			fadeOutPercentage += Time.deltaTime;
        }
        else if (fadeInPercentage < 1)
		{
			//Fade In
			if (fadeInPercentage == 0)
			{
				//Move Player
				transform.position = endPosition;
			}

			fadePlaneRenderer.material.color = Color.Lerp(Color.black, Color.clear, fadeInPercentage);
			fadeInPercentage += Time.deltaTime;
        }
        else
		{
			//Completed
			fadeOutPercentage = 0;
			fadeInPercentage = 0;
			isPlayerMoving = false;
		}
	}

	protected void HandlePlayerMovementDashing()
	{
		//If movement hasn't completed
        if (movementPercentage < 1)
		{
			//Lerp player toward destination
            movementPercentage += Time.deltaTime * dashingSpeed;
            transform.position = Vector3.Lerp(startPosition, endPosition, movementPercentage);
        }
        else
		{
			//Moving is complete, reset variables
            movementPercentage = 0;
            isPlayerMoving = false;
        }
    }
}
