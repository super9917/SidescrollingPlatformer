using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour {

	private float speed;
	void Start () 
	{
		speed = Random.Range (1f, 10f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		gameObject.transform.Translate (Vector2.left * Time.deltaTime * speed); 
	}
}
