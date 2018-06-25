using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerplatform : MonoBehaviour {

	public bool aktiv = false;
	BoxCollider2D Door_trigger;

	void Start () {
		Door_trigger = GameObject.FindGameObjectWithTag ("DoorTrigger").GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (aktiv) {
			Door_trigger.enabled = false;
		} 
		else {
			Door_trigger.enabled = true;		
		}
	}



	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Spieler" || other.gameObject.tag == "Kiste") {
			Debug.Log ("Trigger aktiviert");
			aktiv = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){

		if (other.gameObject.tag == "Spieler" || other.gameObject.tag == "Kiste") {
			Debug.Log ("Trigger deaktiviert");
			aktiv = false;
		}
	}
}