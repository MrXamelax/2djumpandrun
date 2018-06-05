using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	#region Singleton
	public static Inventory instance;
	void Awake(){
		if (instance)
			Debug.LogError ("Mehrere Inventare auf" + transform.name);
		instance = this;
	}
	#endregion

	public Sprite[] keycards;
	Image[] image_items = new Image[4];
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

		/*
		if (Variablen.keyCount_red == true) {
			Debug.Log (Variablen.keyCount);
			keyRed = image_items [0];
			//image_items [Variablen.keyCount - 1].sprite = keycardRed;
			//image_items [Variablen.keyCount - 1].enabled = true;
			image_items[0].enabled = true;
		} else {
			image_items[2].enabled = false;
			//image_items[Variablen.keyCount].enabled = false;
		}
			
		if (Variablen.keyCount_gold == true) {
			Debug.Log (Variablen.keyCount);
			//image_items[Variablen.keyCount - 1].enabled = true;
			image_items[0].enabled = true;
		} else {
			image_items[0].enabled = false;
			//image_items[Variablen.keyCount].enabled = false;
		}

		if (Variablen.keyCount_blue == true) {
			Debug.Log (Variablen.keyCount);
			image_items[1].enabled = true;
			//image_items[Variablen.keyCount - 1].enabled = true;
		} else {
			image_items[1].enabled = false;
			//image_items[Variablen.keyCount].enabled = false;
		}

		if (Variablen.keyCount_green == true) {
			Debug.Log (Variablen.keyCount);
			image_items[3].enabled = true;
			//image_items[Variablen.keyCount - 1].enabled = true;
		} else {
			image_items[3].enabled = false;
			//image_items[Variablen.keyCount].enabled = false;
		}

		/*else if (Variablen.keyCount_gold == true) {
			
			image_items [Variablen.keyCount - 1].enabled = true;
		} else if (Variablen.keyCount_blue == true) {
			
			image_items [Variablen.keyCount - 1].enabled = true;
		} else if (Variablen.keyCount_green == true) {
			
			image_items[Variablen.keyCount -1].enabled = true;
		}

		*/


	}

}
