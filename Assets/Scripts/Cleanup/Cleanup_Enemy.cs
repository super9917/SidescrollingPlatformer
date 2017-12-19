using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Cleanup_Enemy : MonoBehaviour {

	[HideInInspector] public int howManyEnemiesPassed = 0;
	public AudioSource[] audioSources; 
	public AudioClip gameOverClip;
	public Text enemiesPassedCounter;
	private AudioSource gameOverAudioSource;
	void Start()
	{
		gameOverAudioSource = gameObject.GetComponent<AudioSource> ();
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			Destroy (other.gameObject);
			if (howManyEnemiesPassed < 10) 
			{
				howManyEnemiesPassed++;
				enemiesPassedCounter.text = "Enemies Infiltrating: " + howManyEnemiesPassed + " /10";

			}

		}
	}
	void Update()
	{
		if (howManyEnemiesPassed == 10) {
			foreach (AudioSource audioSource in audioSources) {
				audioSource.Stop ();
			}
		}
	}
	//void SoundGameOver()
	//{

	//	gameOverAudioSource.Play ();
	//}
}
