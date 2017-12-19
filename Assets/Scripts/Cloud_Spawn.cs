using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_Spawn : MonoBehaviour {

	public float resetDistance = 30;
	public GameObject cloudPrefab;
	private Vector2 resetPosition;
	private float spawnRangeX;
	private float spawnRangeY;
	private float scaleRangeX;
	private float scaleRangeY;
	private Vector3 scale;
	private Transform cloudCloneTransformScale;
	private GameObject CloudClone;
	void Start () {
		resetPosition = Vector2.right * resetDistance;
		InvokeRepeating ("CreateCloud", 0f, 5f);
	}
	void Update () {
		scaleRangeX = Random.Range (2f, 4f);
		scaleRangeY = Random.Range (2f, 4f);
	}
	void CreateCloud()
	{
		spawnRangeY = Random.Range (2f, 4.5f);
		spawnRangeX = Random.Range (14f, 17.5f);
		CloudClone = (GameObject) Instantiate (cloudPrefab, new Vector2 (spawnRangeX, spawnRangeY), Quaternion.identity);
		scale = CloudClone.transform.localScale;
		scale.x = scaleRangeX;
		scale.y = scaleRangeY;
		CloudClone.transform.localScale = scale;
	}
	// Update is called once per frame
}
