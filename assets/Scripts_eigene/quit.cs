//	Importierte Klassen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour {

	//	Methode zum Beenden des Spiels
	public void Quit(){
		Debug.Log ("Button geklickt. Spiel beendet!");

		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
}
