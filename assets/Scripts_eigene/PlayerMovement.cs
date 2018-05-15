using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rb; 
	float horizontal;
	[SerializeField] private float speed;
	Animator playerAnim;
	[SerializeField] private float jumpForce;
	bool grounded;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		playerAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		horizontal = Input.GetAxis ("Horizontal");
		rb.velocity = new Vector2 (horizontal * speed,rb.velocity.y);
		playerAnim.SetFloat ("speed", Mathf.Abs (horizontal));

		if (horizontal < 0) {
			transform.localScale = new Vector3 (-1, 1, 1);
		}

		if (horizontal > 0) {
			transform.localScale = new Vector3 (1, 1, 1);
		}


		//Jump
		if (Input.GetButtonDown("Jump") && grounded == true){
			Debug.Log ("Springen");
			rb.AddForce (transform.up * jumpForce);
			grounded = false; 
			playerAnim.SetTrigger ("Jump");
		}

	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.collider.tag == "Boden") {
			Debug.Log ("Untergrund");
			grounded = true;
		} else {
			Debug.Log ("Nicht der Untergrund");
		}
	}
}
