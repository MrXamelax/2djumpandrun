//	Importierte Klassen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	//	Instanz von Inventory wird erzeugt
	#region Singleton
	public static Inventory instance;

	//	Wird einmaling und als erstes beim Aufrufen des Scripts ausgeführt (noch vor "Start"-Methode)
	void Awake(){
		instance = this;
	}
	#endregion


	//	Sprite-Array wird erstellt und im Inspector bestückt
	public Sprite[] keycards;

	//	Image-Array wird erstellt und in Start-Methode mit 4 Einträgen initialisiert
	Image[] image_items = new Image[4];

	//	Liste für Sprite-Elemente wird erstellt und initialisiert
	List<Sprite> collectedCards = new List<Sprite>();

	//	Wird einmaling und als erstes beim Aufrufen des Scripts ausgeführt
	void Start () {

		//	Image-Array wird gefüllt mit bereits existierenden Image-Componenten und einzelne Bilder werden deaktiviert und geleert
		for (int i=0; i<4; i++) {
			image_items[i] = GameObject.FindGameObjectWithTag ("item"+i).GetComponent<Image> ();
			image_items[i].enabled = false;
			image_items[i].sprite = null;
		}
	}

	// 	Wird beim Aufsammeln einer Schlüsselkarte oder beim Aufschließen einer Tür vom Spieler-Script aus aufgerufen
	//	Also immer dann, wenn sich das Inventar verändert 
	public void DrawInventory (byte i, bool add) {

		//	Exit-Code für diese Methode
		if (i == 255)
			return;

		//	Wenn eine Schlüsselkarte aufgesammelt wurde, wird sie über die mitgegebene Nummer der Liste hinzugefügt...
		if (add) {
			collectedCards.Add (keycards [i]);

		//	...bzw wenn sie benutzt wurde von der Liste entfernt
		} else {
			collectedCards.Remove (keycards [i]);
		}

		//	Schlüsselkarten werden an aktuellem Zählstand geladen und angezeigt...
		for (int j = 0; j < image_items.Length; j++) {
			if (collectedCards.Count > j) {
				image_items [j].sprite = collectedCards [j];
				image_items [j].enabled = true;

			//	...bzw ausgeblendet
			} else {
				image_items [j].enabled = false;
			}
		}
	}
}