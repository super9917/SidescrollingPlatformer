using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

	[HideInInspector] public bool jump = false;
	// Use this for initialization
	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 250f;
	private int howManyJumpsMade = 0;
	private Transform groundCheck;
	private AudioSource playerAudio; 
	private bool grounded = false;
	public float minX = -12.8f;
	public float maximumX = 12.75f;
	private Rigidbody2D rb2d;
	static private Vector2 currentPositon;
	Animator anim;
	void Start () {
		anim = GetComponent<Animator> ();
		playerAudio = gameObject.GetComponent<AudioSource> ();
		currentPositon = transform.position;
		rb2d = GetComponent<Rigidbody2D> ();
		groundCheck = GameObject.Find ("GroundTrigger").GetComponent<Transform> ();

	}
	
	// Update is called once per frame
	void OnCollisionStay2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Ground") {
			grounded = true;
		}
	}
	void OnCollisionExit2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Ground") {
			grounded = false;
		}
	}
	void Update () 
	{
		currentPositon.x = Mathf.Clamp (currentPositon.x, minX, maximumX);
		if (Input.GetKeyDown(KeyCode.Space) && grounded || (Input.GetKeyDown(KeyCode.Space) && howManyJumpsMade < 2)) 
		{
			jump = true;
		}
		if (howManyJumpsMade >= 2 && grounded) {
			howManyJumpsMade = 0;
		}
		if (Input.GetKey (KeyCode.A) && transform.position.x > minX) {
				gameObject.transform.Translate (Vector2.left * Time.deltaTime * 5);

			}
		if (Input.GetKey (KeyCode.D) && transform.position.x < maximumX) {
				gameObject.transform.Translate (Vector2.right * Time.deltaTime * 5);

			}
		}

	void FixedUpdate()
	{
		
		if (jump) 
		{
			PlayerJump ();
		}
		jump = false;


	}
	void PlayerJump()
	{	
		playerAudio.Play ();
		rb2d.AddForce (new Vector2 (0f, jumpForce));
		grounded = false;
		howManyJumpsMade++;

	}

	
		



}
