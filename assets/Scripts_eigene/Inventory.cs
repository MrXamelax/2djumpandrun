using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {


	Image keyRed; 
	Image keyGold; 
	Image keyBlue; 
	Image keyGreen; 


	public Sprite keycardRed;
	public Image[] image_items = new Image[4];

	void Start () {
		
		for (int i=0; i<4; i++) {
			image_items[i] = GameObject.FindGameObjectWithTag ("item"+i).GetComponent<Image> ();
			image_items[i].enabled = false;
		}

		//keycardRed = GameObject.FindGameObjectWithTag("KeycardRed").GetComponent<Sprite>();
		//keycardRed = Resources.Load<Sprite>("KeycardRot");


		keyRed = GameObject.FindGameObjectWithTag ("KeycardRed").GetComponent<Image> ();
		keyGold = GameObject.FindGameObjectWithTag ("KeycardGold").GetComponent<Image> ();
		keyBlue = GameObject.FindGameObjectWithTag ("").GetComponent<Image> ();
		keyGreen = GameObject.FindGameObjectWithTag ("").GetComponent<Image> ();


	}
	
	// Update is called once per frame
	void Update () {
		if (Variablen.keyCount_red == true) {
			Debug.Log (Variablen.keyCount);
			//image_items [Variablen.keyCount - 1].sprite = keycardRed;
			//image_items [Variablen.keyCount - 1].enabled = true;
			image_items[2].enabled = true;
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
