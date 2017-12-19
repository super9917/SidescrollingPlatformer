using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour {

	public float movementSpeed = 1f;
	public float endPosition = -12f;
	private Vector3 cloudScale;
	void Start () {
		cloudScale = gameObject.transform.localScale;
		if (cloudScale.x < 3 && cloudScale.y < 3) {
			movementSpeed = 2;
		} else
			if (cloudScale.x > 3 && cloudScale.y > 3) {
			movementSpeed = 1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate (Vector2.left * Time.deltaTime * movementSpeed);
		if(transform.position.x < endPosition)
		{
			Destroy (gameObject);
		}
	}
}
