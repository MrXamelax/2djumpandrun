// 	Importierte Klassen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour {

	//	 Erstellen eines LevelManagers
	public LevelManager levelManager; 

	// 	Wird einmaling und als erstes beim Aufrufen des Scripts ausgeführt
	void Start () {

		//	 Initialisierung des LevelManagers mit einem bereits existierendem
		levelManager = FindObjectOfType<LevelManager>();
	}

	// 	Wird aufgerufen, wenn der Trigger des checkpoint-Objekts mit einem anderen kollidiert
	void OnTriggerEnter2D(Collider2D other){
	
		//	 Falls es mit dem des Spielers kollidiert, wird ein neuer Checkpoint gesetzt
		if (other.tag == "Spieler") {
			Debug.Log ("Checkpoint erreicht!");

			//	 Neuen Checkpoint setzen
			levelManager.currentCheckpoint = gameObject;
		}
	}
}
