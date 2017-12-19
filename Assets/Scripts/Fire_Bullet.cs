using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire_Bullet : MonoBehaviour {


	public GameObject bulletPrefab;
	private AudioSource bulletSoundSource;
	public AudioClip laserSustainSound;
	public AudioClip laserSound;
	public Text rapidFireText;
	public Transform bulletSpawnLocation;
	public int bulletsLeft = 999;
	public bool hasRapidFirePowerUp = false;
	void Start()
	{
		rapidFireText.gameObject.SetActive (false);
		bulletSoundSource = gameObject.GetComponent<AudioSource> ();
	}

	void Update()
	{	
		rapidFireText.gameObject.SetActive (false);
		if (bulletsLeft > 0 && Input.GetKeyDown (KeyCode.F)) {
			FireBullet ();
		} 
		if (bulletsLeft > 0 && Input.GetKey (KeyCode.F) && hasRapidFirePowerUp == true) {
			RapidFire ();
		}
	}
	void FireBullet()
	{
		var bullet = (GameObject)Instantiate 
			(bulletPrefab, bulletSpawnLocation.position, bulletSpawnLocation.rotation);
		bullet.GetComponent<Rigidbody2D> ().velocity = bullet.transform.right * 30;
		bulletSoundSource.PlayOneShot (laserSound);
		bulletsLeft--;
		//Debug.Log("Bullets Remaining:" + bulletsLeft);
		Destroy (bullet, 2.0f);

	}
	void RapidFire()
	{
		rapidFireText.gameObject.SetActive (true);
		if (bulletSoundSource.isPlaying == false) {
			bulletSoundSource.PlayOneShot (laserSustainSound);
		}
		var bullet = (GameObject)Instantiate (bulletPrefab, bulletSpawnLocation.position, bulletSpawnLocation.rotation);
		bullet.GetComponent<Rigidbody2D> ().velocity = bullet.transform.right * 30;
		bulletsLeft--;
		Destroy (bullet, 2.0f);
	}

}
