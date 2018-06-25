//	Importierte Klassen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Menu : MonoBehaviour {

	//	Tramsform-Objekt wird erzeugt
	public Transform canvas;

	// 	Wird einmal pro Bildaktualisierung aufgerufen
	void Update () {

		//	Wenn momentan kein anderes Menü geöffnet ist und der Knopf zum Pausieren/Fortsetzen gedrückt wird...
		if (Variablen.allowPause && Input.GetButtonDown ("Pause") ) 
		{

			//	...so wird die Pause-Methode aufgerufen
			Pause();	
		}
	}

	//	Methode zum Pausieren des Spiels
	public void Pause()
	{

		//	Wenn das Pausenmenü noch nicht aktiviert ist...
		if (canvas.gameObject.activeInHierarchy == false) {

			//	Wird es aktiviert und der Zeitfaktor auf 0 gesetzt (Zeit bleibt stehen und Spiel pausiert)
			canvas.gameObject.SetActive (true);
			Time.timeScale = 0;

		//	...ansonsten...
		} else {

			//	...wird das Pausenmenü deaktiviert und der Zeitfaktor auf 1 gesetzt (Spiel setzt fort)
			canvas.gameObject.SetActive (false);	
			Time.timeScale = 1;
		}
	}
}
