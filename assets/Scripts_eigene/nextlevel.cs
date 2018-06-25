//	Importierte Klassen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextlevel : MonoBehaviour {

	// 	Wird aufgerufen, wenn der Trigger des leiter-Objekts mit einem anderen kollidiert
	void OnTriggerEnter2D(Collider2D other) {
		
		Debug.Log ("Level geschafft!");

		//	nächste Scene wird über den SceneManager geladen
		if(other.tag == "Spieler") {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
		}
	}

}
