using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chainsaw : MonoBehaviour {

	public LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Spieler"){
			levelManager.RespawnPlayer ();
		}
	}
}
