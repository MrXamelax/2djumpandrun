//	Importierte Klassen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	//	Benötigte Variablen und Objekte werden erstellt
	bool grounded; 
	float horizontal;
	Animator playerAnim;
	Rigidbody2D rb;
	[SerializeField] private float speed;
	[SerializeField] private float jumpForce;


	//	Wird einmaling und als erstes beim Aufrufen des Scripts ausgeführt
	void Start () {

		//	Rigidbody des Spielers und sein Animator werden initialisiert
		rb = GetComponent<Rigidbody2D> ();
		playerAnim = GetComponent<Animator> ();
	}

	//	Wird eine festgelegte Anzahl mal pro Sekunde aufgerufen
	void FixedUpdate() {

		//	Variablen und Objekte werden initialisiert
		horizontal = Input.GetAxis ("Horizontal");
		rb.velocity = new Vector2 (horizontal * speed, rb.velocity.y);
		playerAnim.SetFloat ("speed", Mathf.Abs (horizontal));

		//	Bewegung nach links
		if (horizontal < 0) {
			transform.localScale = new Vector3 (-0.874032f, 0.874032f, 0.874032f);
		}

		//	Bewegung nach rechts
		if (horizontal > 0) {
			transform.localScale = new Vector3 (0.874032f, 0.874032f, 0.874032f);
		}


		//	Wenn Sprung-Taste gedrückt wird und sich der Spieler auf dem Boden befindet wird...
		if (Input.GetButtonDown("Jump") && grounded == true) {
			Debug.Log ("Springen");

			//	...der Sprung ausgelöst und somit der Rigidbody des Spielers geändert
			rb.AddForce (transform.up * jumpForce);

			//	...die Prüfvariable dafür, ob der Spieler auf etwas steht auf "falsch" gesetzt
			grounded = false; 

			//	...die Sprunganimation ausgelöst
			playerAnim.SetTrigger ("Jump");
		}
	}

	// 	Wird aufgerufen, wenn das Spieler-Objekt mit einem anderen kollidiert
	void OnCollisionEnter2D(Collision2D other){

		//	Falls es mit einem Objekt mit dem Tag "Boden" oder "Kiste" kollidiert...
		if (other.collider.tag == "Boden" || other.collider.tag =="Kiste") {
			Debug.Log ("Untergrund");

			//	...wird die Prüfvariable dafür, ob der Spieler auf etwas steht auf "wahr" gesetzt
			grounded = true;
		} else {
			Debug.Log ("Nicht der Untergrund");
		}
	}
}
