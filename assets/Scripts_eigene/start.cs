//	Importierte Klassen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour {

	//	Szenenname wird als String erstellt
	public string sceneName;

	//	Übergebene Szene wird geladen
	public void StartLevel() {
		SceneManager.LoadScene (sceneName);	
	}
}
