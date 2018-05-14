using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leiter : MonoBehaviour {

	public float climbSpeed;
	float climbVelocity;
	Rigidbody2D playerRB;
	public bool anLeiter = false;

	void Start () {
		playerRB = GameObject.FindGameObjectWithTag ("Spieler").GetComponent<Rigidbody2D> ();
	}
	

	void Update () {

		if (anLeiter) {
			climbVelocity = climbSpeed * Input.GetAxisRaw ("Vertical");
			playerRB.velocity = new Vector2 (0, climbVelocity);

		} 
	}


	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Spieler") {
			anLeiter = true;
			playerRB.gravityScale = 0f;
		} 

	}

	void OnTriggerExit2D(Collider2D other)
	{
		anLeiter = false;
		playerRB.gravityScale = 10f;
	}
}
