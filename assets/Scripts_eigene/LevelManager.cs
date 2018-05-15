using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {


	//aktuelle Checkpoint
	public GameObject currentCheckpoint;

	//spieler gameobjekt
	public GameObject spieler;
	AudioSource audio_dead;

	void Start(){
	
		audio_dead = GameObject.FindGameObjectWithTag ("Dead").GetComponent<AudioSource> ();
	}
		
	public void RespawnPlayer(){
	
			//Spieler an Checkpoint Position bringen
		audio_dead.Play ();
		spieler.transform.position = currentCheckpoint.transform.position;
	
	
	}
}
