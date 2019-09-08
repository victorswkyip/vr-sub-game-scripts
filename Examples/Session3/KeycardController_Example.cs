using UnityEngine;

public class KeycardController_Example : MonoBehaviour
{
	//Keycard Info
	public KeycardType keycardType;

	//Inventory
	public InventoryManager_Example inventoryManager;

	//Visualization Variables
    public Transform keycardMesh;
    public float rotateSpeed = 120;

    protected bool isSelected;
    protected float rotationAmount;


    void Update ()
	{
		//Rotate Card when Selected
		if (isSelected)
		{
            rotationAmount += Time.deltaTime * rotateSpeed;
            keycardMesh.rotation = Quaternion.Euler(0, rotationAmount, 0);
        }
    }

  
	//Pick up the Card
    public void OnClicked()
	{
		//Acquire keycard in inventory
		inventoryManager.AcquireKeycard(keycardType);

		//Destroy card on ground
		Destroy(gameObject);
    }

	//Player is looking at object
    public void OnFocused()
	{
        isSelected = true;
    }

	//Player has looked away from object
    public void OnDefocused()
	{
        isSelected = false;
    }
}
