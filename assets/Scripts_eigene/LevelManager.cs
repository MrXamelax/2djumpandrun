//	Importierte Klassen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {


	//	Benötigte Objekte werden erstellt
	public GameObject currentCheckpoint;
	public GameObject spieler;
	AudioSource audio_dead;

	//	Wird einmaling und als erstes beim Aufrufen des Scripts ausgeführt
	void Start() {

		//	Tonquelle wird initialisiert
		audio_dead = GameObject.FindGameObjectWithTag ("Dead").GetComponent<AudioSource> ();
	}

	//	Methode zum Zurücksetzen des Spielers
	public void RespawnPlayer() {
	
		//	Sterbeton wird abgespielt und Spieler wird zum letzten erreichten Chckpoint zurückgesetzt
		audio_dead.Play ();
		spieler.transform.position = currentCheckpoint.transform.position;
	}
}
