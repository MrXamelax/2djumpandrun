//	 Importierte Klassen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chainsaw : MonoBehaviour {

	//	 Erstellen eines LevelManagers
	public LevelManager levelManager;

	// 	Wird einmaling und als erstes beim Aufrufen des Scripts ausgeführt
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
	}
	
	// 	Wird einmal pro Bildaktualisierung aufgerufen
	void Update () {
		
	}

	// 	Wird aufgerufen, wenn das chainsaw-Objekt mit einem anderen kollidiert
	void OnCollisionEnter2D(Collision2D other){

		//	 Falls es mit dem Spieler kollidiert, so wird der Spieler über den LevelManager zurückgesetzt zurückgesetzt
		if(other.gameObject.tag == "Spieler"){
			levelManager.RespawnPlayer ();
		}
	}
}
