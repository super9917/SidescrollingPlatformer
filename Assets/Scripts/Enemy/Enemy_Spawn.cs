using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour {

		
	public GameObject prefab;
	[HideInInspector] public GameObject clone;
	private GameObject[] getCountOfFlys;
	int x = 14;
	float y;
	public float timeToSpawn = 1.5f;
	[HideInInspector] public static int count;
	// Use this for initialization
	void Start()
	{
		getCountOfFlys = GameObject.FindGameObjectsWithTag ("Enemy");
		count = getCountOfFlys.Length;
		InvokeRepeating ("CreateEnemyFly", 0f, timeToSpawn);
	}
	// Update is called once per frame
	void Update () {
		//Debug.Log (count);
	}
	void CreateEnemyFly()
	{	
		y = Random.Range (-3.5f, -0.5f);
		clone = (GameObject)Instantiate (prefab, new Vector2 (x, y), Quaternion.identity);
	}


}
