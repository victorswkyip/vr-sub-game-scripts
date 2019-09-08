using UnityEngine;

public enum KeycardType { Blue, Yellow, Red };
public class InventoryManager_Example : MonoBehaviour
{
    public Transform cameraTransform;

	//Keycard Objects
    public GameObject keycardBlue;
    public GameObject keycardYellow;
    public GameObject keycardRed;

	//Tracker variables
	protected bool hasBlueKeycard = false;
	protected bool hasYellowKeycard = false;
	protected bool hasRedKeycard = false;
	
	void Update ()
	{
        //Rotate the inventory with the camera so cards will always be in front of us
        transform.eulerAngles = new Vector3(0, cameraTransform.eulerAngles.y, 0);
	}

	public void AcquireKeycard(KeycardType keycardType)
	{
		//Depending on the color of the keycard, set the inventory representation
		//to active, and set our tracker bool to true

		if (keycardType == KeycardType.Blue)
		{
			keycardBlue.SetActive(true);
			hasBlueKeycard = true;
		}
		else if (keycardType == KeycardType.Red)
		{
			keycardRed.SetActive(true);
			hasRedKeycard = true;
		}
		else if (keycardType == KeycardType.Yellow)
		{
			keycardYellow.SetActive(true);
			hasYellowKeycard = true;
		}
	}

	public bool HasKeycard(KeycardType keycardType)
	{
		//Use tracker bools to return info on whether the user has that keycard

		if (keycardType == KeycardType.Blue)
		{
			return hasBlueKeycard;
		}
		else if (keycardType == KeycardType.Red)
		{
			return hasRedKeycard;
		}
		else if (keycardType == KeycardType.Yellow)
		{
			return hasYellowKeycard;
		}
		return false;
	}
}
