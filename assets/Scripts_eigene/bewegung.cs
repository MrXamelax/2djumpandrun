// 	Importierte Klassen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bewegung : MonoBehaviour {

	//	 Erstellung von 2 Vektoren um später Spielerposition zu ändern

	private Vector3 startPos;
	private Vector4 newPos;

	// 	Erstellung einer Fließkommavariable, um die Geschwindigkeit des Spielers anpassen zu können
	public float speed = 10f;

	// 	Wird einmaling und als erstes beim Aufrufen des Scripts ausgeführt
	void Start () {

		//	 Erster Vektor wird mit der aktuellen Spielerposition initialisiert
		startPos = transform.position;
	}
	
	// 	Wird einmal pro Bildaktualisierung aufgerufen
	void Update () {

		//	 Zweiter Vektor wird mit aktuellem ersten Vektor initialisiert
		newPos = startPos;

		// 	x-Wert des zweiten Vektors wird verändert
		newPos.x = newPos.x + Mathf.PingPong (Time.time * speed, 40);

		// 	Aktuelle Spielerposition wird auf den veränderten zweiten Vektor gesetzt -> Spieler bewegt sich
		transform.position = newPos;
	}
}
