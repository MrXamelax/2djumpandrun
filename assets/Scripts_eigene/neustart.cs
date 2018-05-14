using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class neustart : MonoBehaviour {

	public LevelManager levelManager;

	void Start (){
		levelManager = FindObjectOfType<LevelManager> ();
	} 

	void OnTriggerEnter2D(Collider2D other) {

		Debug.Log ("Spieler ist tot!");
		if(other.tag == "Spieler"){
			levelManager.RespawnPlayer ();
		}
	}

}
