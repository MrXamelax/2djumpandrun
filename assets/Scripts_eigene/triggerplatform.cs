using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerplatform : MonoBehaviour {

	//	Prüfvariable ob TriggerPlatform aktiv ist und Objekt der Stahltür werden erstellt
	public bool aktiv = false;
	BoxCollider2D Door_trigger;

	// 	Wird einmaling und als erstes beim Aufrufen des Scripts ausgeführt
	void Start () {

		//	Stahltür-Objekt wird initialisiert
		Door_trigger = GameObject.FindGameObjectWithTag ("DoorTrigger").GetComponent<BoxCollider2D> ();
	}
	
	// 	Wird einmal pro Bildaktualisierung aufgerufen
	void Update () {

		//	Wenn die TriggerPlatform aktiviert wird...
		if (aktiv) {

			//	...wird die Stahltür deaktiviert
			Door_trigger.enabled = false;
		} 
		else {

			//	...bzw. andersrum aktiviert
			Door_trigger.enabled = true;		
		}
	}
		
	// 	Wird aufgerufen, wenn der Trigger des TriggerPlatform-Objekts mit einem anderen kollidiert
	void OnTriggerEnter2D(Collider2D other){

		//	Falls es der Spieler oder die Kiste ist, so wird die Prüfvariable auf wahr gesetzt
		if (other.gameObject.tag == "Spieler" || other.gameObject.tag == "Kiste") {
			Debug.Log ("Trigger aktiviert");
			aktiv = true;
		}
	}

	// 	Wird aufgerufen, wenn der Trigger des TriggerPlatform-Objekts von einem anderen verlassen wird
	void OnTriggerExit2D(Collider2D other){

		//	Falls es der Spieler oder die Kiste ist, so wird die Prüfvariable auf falsch gesetzt
		if (other.gameObject.tag == "Spieler" || other.gameObject.tag == "Kiste") {
			Debug.Log ("Trigger deaktiviert");
			aktiv = false;
		}
	}
}