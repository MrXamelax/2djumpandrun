//	Importierte Klassen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leiter : MonoBehaviour {

	//	Erstellung der Variablen und Objekte zur Konfiguration des Kletterns an der Leiter
	public float climbSpeed;
	float climbVelocity;
	public bool atLadder = false;

	//	Erstellung des Rigidbodys für den Spieler um änderungen an diesem vornehmen zu können
	Rigidbody2D playerRB;

	//	Wird einmaling und als erstes beim Aufrufen des Scripts ausgeführt
	void Start () {

		//	Initialisierung des Rigidbodys für den Spieler
		playerRB = GameObject.FindGameObjectWithTag ("Spieler").GetComponent<Rigidbody2D> ();
	}
	
	// 	Wird einmal pro Bildaktualisierung aufgerufen
	void Update () {

		//	Wenn sich der Spieler an der Leiter befindet, wird die Klettergeschwindigkeit berechnet
		//	und die Bewegungsgeschwindigkeit des Spielers in y-Richtung dementsprechend geändert
		if (atLadder) {
			climbVelocity = climbSpeed * Input.GetAxisRaw ("Vertical");
			playerRB.velocity = new Vector2 (0, climbVelocity);
		} 
	}

	// 	Wird aufgerufen, wenn der Trigger des leiter-Objekts mit einem anderen kollidiert
	void OnTriggerEnter2D(Collider2D other) {

		//	Falls es mit dem Spieler kollidiert wird die Prüfvariable auf "wahr" gesetzt und die Gravitation des Spielers auf 0
		//	Sprich der Spieler befindet sich nun an der Leiter und fällt somit auch nicht mehr
		if (other.gameObject.tag == "Spieler") {
			atLadder = true;
			playerRB.gravityScale = 0f;
		} 
	}

	// 	Wird aufgerufen, wenn ein Objekt den Trigger des Leiter-Objekts verlässt
	void OnTriggerExit2D(Collider2D other) {

		//	Prüfvariable wird auf "falsch" gesetzt und die Gravitation des Spielers auf 10
		//	Sprich der Spieler befindet sich nun nicht mehr an der Leiter und fällt somit auch wieder
		atLadder = false;
		playerRB.gravityScale = 10f;
	}
}
