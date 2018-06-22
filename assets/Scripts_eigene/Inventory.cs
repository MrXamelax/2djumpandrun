// Importierte Klassen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	// Instanz von Inventory wird erzeugt
	#region Singleton
	public static Inventory instance;

	// Wird einmaling und als erstes beim Aufrufen des Scripts ausgeführt (noch vor "Start"-Methode)
	void Awake(){
		instance = this;
	}
	#endregion


	// Sprite-Array wird erstellt und im Inspector bestückt
	public Sprite[] keycards;

	// Image-Array wird erstellt und in Start-Methode mit 4 Einträgen initialisiert
	Image[] image_items = new Image[4];

	// 
	List<Sprite> collectedCards = new List<Sprite>();

	void Start () {
		for (int i=0; i<4; i++) {
			image_items[i] = GameObject.FindGameObjectWithTag ("item"+i).GetComponent<Image> ();
			image_items[i].enabled = false;
			image_items[i].sprite = null;
		}
	}

	public void DrawInventory (byte i, bool add) {
		if (i == 255)
			return;

		if (add) {
			collectedCards.Add (keycards [i]);
		} else {
			collectedCards.Remove (keycards [i]);
		}

		for (int j = 0; j < image_items.Length; j++) {
			if (collectedCards.Count > j) {
				image_items [j].sprite = collectedCards [j];
				image_items [j].enabled = true;
			} else {
				image_items [j].enabled = false;
			}
		}
	}
}
