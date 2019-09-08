using UnityEngine;

public class MissileController_Example : MonoBehaviour
{
	public float speed;
	public float maxLifetime = 10;

	protected float lifetime = 0;

	void Update()
	{
		transform.position += transform.forward * Time.deltaTime * speed;

		//Self destruct after lifetime expires
		lifetime += Time.deltaTime;
		if (lifetime > maxLifetime)
		{
			Destroy(gameObject);
		}
	}

	public GameObject explosionPrefab;

	void OnTriggerEnter(Collider other)
	{
		//Create Explosion
		Instantiate(explosionPrefab, transform.position, transform.rotation);

		//Destroy other object if it has Destroy tag
		if (other.gameObject.tag == "Destroy")
		{
			Destroy(other.gameObject);

			//Figure out how many destroyable gameobjects  are left
			int amountLeft = GameObject.FindGameObjectsWithTag("Destroy").Length - 1;

			if (amountLeft > 0)
			{
				//Update UI with number of objects remaining
				UIHelper_Example.ChangeText("Destroy " + amountLeft + " more to win!");
			}
			else
			{
				//Update UI with Win Text
				UIHelper_Example.ChangeText("You win!");
				SubmarineController_Example.alive = false;
			}
		}

		Destroy(gameObject);
	}
}
