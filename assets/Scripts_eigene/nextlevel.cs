using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextlevel : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D other) {

		Debug.Log ("Level geschafft!");
		if(other.tag == "Spieler"){
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
		}
	}

}
