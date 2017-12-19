using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {


	Animator anim;
	private Cleanup_Enemy enemyCleanup;
	float restartTimer;
	float restartDelay = 5f;
	private AudioSource GameOverAudioSource;
	[HideInInspector] public bool isGameOver = false;
	public GameObject gameOverPanel;
	private Scene currentScene;
	void Awake()
	{
		anim = GetComponent<Animator> ();
		gameOverPanel.SetActive (false);
	}
	void Start () 
	{
		currentScene = SceneManager.GetActiveScene ();
		GameOverAudioSource = gameObject.GetComponent<AudioSource> ();
		GameObject enemyCleanupObject = GameObject.FindWithTag ("EnemyCleanup");
		if(enemyCleanupObject != null)
		{
			enemyCleanup = enemyCleanupObject.GetComponent<Cleanup_Enemy> ();
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (enemyCleanup.howManyEnemiesPassed == 10) {
			TriggerGameOver();
		}
	}
	void PlayGameOverSound()
	{
		GameOverAudioSource.Play ();
	}
	void TriggerGameOver ()
	{
		isGameOver = true;
		anim.SetTrigger ("GameOver");
		restartTimer += Time.deltaTime;
	}
	public void MakeRestartButtonAppear()
	{
		gameOverPanel.SetActive (true);
	}
	public void RestartGame()
	{
		SceneManager.LoadScene (currentScene.name);
	}
}

