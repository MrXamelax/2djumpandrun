//	Importierte Klassen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

	// 	Wird aufgerufen, wenn der Trigger des Trigger-Objekts mit einem anderen kollidiert
	void OnTriggerEnter2D(Collider2D other){

		//	Falls es der Spieler ist, so wird das Objekt welches dieses Skript beherbergt zerstört
		if (other.gameObject.tag == "Spieler") {
			Destroy (gameObject);
		}
	}
}