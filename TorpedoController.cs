using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TorpedoController : MonoBehaviour {

	public float speed = 10.0f; //declare speed variable
	public GameObject explosionPrefab; //create gameobject

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 20f); //destroys after 20 sconds
	}

	// Update is called once per frame
	void Update () {
		this.transform.position += this.transform.forward * speed * Time.deltaTime; //update position at unit*frames/second
	}


	void OnTriggerEnter (Collider thingWeHit) {
		if (thingWeHit.tag == "Destroyable") {
			Destroy (thingWeHit.gameObject); //destory target
			GameObject[] destroyableObjects = GameObject.FindGameObjectsWithTag("Destroyable");
			if (destroyableObjects.GetLength (0)-1 == 0) {
				UIHelper_Example.ChangeText ("YOU WIN! WOOT!");
				//Invoke ("ReloadGame", 5f);
				//ReloadGame();
			} else {
				UIHelper_Example.ChangeText ("You have " + (destroyableObjects.GetLength (0)-1) + " to destroy");
			}
				
		}

		GameObject newExplosion = Instantiate (explosionPrefab) as GameObject; //creates a new instance of game object
		newExplosion.transform.position = this.transform.position; //tells the game where to instantiate
		newExplosion.transform.rotation = this.transform.rotation;

		Destroy (this.gameObject); //destroy the torpedo 
	}
	public void ReloadGame(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

}
