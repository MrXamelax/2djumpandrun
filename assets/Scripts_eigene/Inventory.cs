using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {


	Image image_red; 
	Image image_gold; 
	Image image_blue; 
	Image image_green; 

	void Start () {
		image_red = GameObject.FindGameObjectWithTag ("Schlüssel_rot").GetComponent<Image> ();
		image_gold = GameObject.FindGameObjectWithTag ("Schlüssel_gold").GetComponent<Image> ();
		image_blue = GameObject.FindGameObjectWithTag ("Schlüssel_blau").GetComponent<Image> ();
		image_green = GameObject.FindGameObjectWithTag ("Schlüssel_grün").GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Variablen.keyCount_red > 0) {
			image_red.enabled = true;
		} else {
			image_red.enabled = false;
		}

		if (Variablen.keyCount_gold > 0) {
			image_gold.enabled = true;
		} else {
			image_gold.enabled = false;
		}

		if (Variablen.keyCount_blue > 0) {
			image_blue.enabled = true;
		} else {
			image_blue.enabled = false;
		}

		if (Variablen.keyCount_green > 0) {
			image_green.enabled = true;
		} else {
			image_green.enabled = false;
		}
	}
}
