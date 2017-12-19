using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Hit : MonoBehaviour {

	private AudioSource deathAudioSource;
	private int clipNumberSelect;
	public AudioClip[] deathSounds;
	private AudioClip selectedClip;
	private Keep_Score keep_score;
	public GameObject explosionPrefab;
	public float explosionTime;
	[HideInInspector] public GameObject clone;
	void Start()
	{
		GameObject levelControllerObject = GameObject.FindWithTag ("LevelController");
		if (levelControllerObject != null) {
			keep_score = levelControllerObject.GetComponent<Keep_Score> ();
		}
		deathAudioSource = GameObject.FindGameObjectWithTag ("DeathSoundSource").GetComponent<AudioSource> ();
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy") {
			Explode ();
			deathAudioSource.PlayOneShot (deathSounds [Random.Range (0, deathSounds.Length)]);
			keep_score.UpdateScore (1);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
	void Explode()
	{
		//Debug.Log ("Exploding");
		clone = (GameObject)Instantiate (explosionPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
		Destroy (clone, explosionTime);
	}

}
