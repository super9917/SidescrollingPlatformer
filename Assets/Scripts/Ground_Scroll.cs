using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Scroll : MonoBehaviour {

	public bool levelIsRunning = true;
	private float destroyTriggerPosition = -12.8295f;
	private float resetDistance = 25.58f;
	public float movementSpeed = 10.0f;
	private Vector2 resetPosition;
	// Use this for initialization
	void Start () {
		resetPosition = Vector2.right * resetDistance;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (levelIsRunning) {
			transform.Translate (Vector2.left * Time.deltaTime * movementSpeed);

			if (transform.position.x < destroyTriggerPosition) {
				transform.Translate (resetPosition);
			}
		}	


	}
}
