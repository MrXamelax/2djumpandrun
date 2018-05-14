using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {


	//aktuelle Checkpoint
	public GameObject currentCheckpoint;

	//spieler gameobjekt
	public GameObject spieler;

	public void RespawnPlayer(){
	
			//Spieler an Checkpoint Position bringen
		spieler.transform.position = currentCheckpoint.transform.position;
	
	}
}
