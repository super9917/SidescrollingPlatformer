using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keep_Score : MonoBehaviour {


	private int levelScore;
	public Text levelScoreText;
	public Text bulletCount;
	private Fire_Bullet bulletInfo;
	void Start () {
		GameObject bulletSpawnPoint_ = GameObject.FindWithTag ("BulletSpawn");
		if (bulletSpawnPoint_ != null) {
			bulletInfo = bulletSpawnPoint_.GetComponent<Fire_Bullet> ();
		}
		levelScore = 0;

	}
	public void UpdateScore(int newLevelScore)
	{
		//Debug.Log ("Score Added");
		levelScore += newLevelScore;
		UpdateLevelScoreText ();
		//Debug.Log (levelScore);
	}
	private void UpdateLevelScoreText()
	{
		levelScoreText.text = "Score: " + levelScore;
		//Debug.Log ("Text Updated");
	}
	// Update is called once per frame
	void Update () {
		bulletCount.text = "Bullets Left: " + bulletInfo.bulletsLeft;
	}
}
