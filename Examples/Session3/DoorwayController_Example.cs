using UnityEngine;

public class DoorwayController_Example : MonoBehaviour
{
	public KeycardType requiredKeyCard;
	public InventoryManager_Example inventoryManager;
	public GameObject slidingDoors;

	protected bool isDoorOpen;

	public bool ToggleDoorOpen()
	{
		//Default is no error
		bool error = false;

		//If the door is already open, close them
		if (isDoorOpen)
		{
			slidingDoors.SetActive(true);
			isDoorOpen = false;
		}
		else //If the doors are closed, attempt to open them
		{
			//If the player has a keycard
            if (inventoryManager.HasKeycard(requiredKeyCard))
			{
				//Open Doors
				slidingDoors.SetActive(false);
				isDoorOpen = true;
            }
            else
			{
				//Set error flag
				error = true;
            }
        }

		//Return whether or not there was an error
		return error;
    }
}
