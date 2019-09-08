using UnityEngine;


public class ParticleDeathController_Example : MonoBehaviour
{
	protected ParticleSystem goParticleSystem;

	void Awake()
	{
		//Assign particle system reference to component
		goParticleSystem = GetComponent<ParticleSystem>();
	}

	void Update()
	{
		//When the particle system is done playing, destroy it
		if (!goParticleSystem.isPlaying)
		{
			Destroy(gameObject);
		}
	}
}
