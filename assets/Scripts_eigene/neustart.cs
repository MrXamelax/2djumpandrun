//	Importierte Klassen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class neustart : MonoBehaviour {

	//	Ein LevelManager wird erstellt
	public LevelManager levelManager;


	// 	Wird einmaling und als erstes beim Aufrufen des Scripts ausgeführt
	void Start () {

		//	levelManager wird initialisiert
		levelManager = FindObjectOfType<LevelManager> ();
	} 

	// 	Wird aufgerufen, wenn der Trigger des killzone-Objekts mit einem anderen kollidiert
	void OnTriggerEnter2D(Collider2D other) {
		
		Debug.Log ("Spieler ist tot!");

		//	Falls es mit dem Spieler kollidiert, so wird er zurückgesetzt
		if(other.tag == "Spieler") {
			levelManager.RespawnPlayer ();
		}
	}

}
