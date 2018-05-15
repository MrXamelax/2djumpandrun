using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spieler : MonoBehaviour {


	private Text textfield;
	private bool inTrigger_blue = false;
	private bool inTrigger_green = false;
	private bool inTrigger_red = false;
	private bool inTrigger_gold = false;
	public static bool CUI_View = false;
	private Text CUI_Info;
	private Text CUI_Text;
	private Image CUI_Bild; 
	Canvas CUI;
	AudioSource audio_red;
	AudioSource audio_blue;
	AudioSource audio_green;
	AudioSource audio_gold;
	Animator door_red_anim;
	Animator door_gold_anim;
	Animator door_green_anim;
	Animator door_blue_anim;

	void Start () {
		textfield = GameObject.FindGameObjectWithTag ("Textfield").GetComponent<Text> ();
		CUI = GameObject.FindGameObjectWithTag ("CUI").GetComponent<Canvas>();
		CUI_Text = GameObject.FindGameObjectWithTag ("CUI_Text").GetComponent<Text>();
		CUI_Info = GameObject.FindGameObjectWithTag ("CUI_Info").GetComponent<Text>();
		audio_red = GameObject.FindGameObjectWithTag ("Door_red").GetComponent<AudioSource> ();
		audio_blue = GameObject.FindGameObjectWithTag ("Door_blue").GetComponent<AudioSource> ();
		audio_green = GameObject.FindGameObjectWithTag ("Door_green").GetComponent<AudioSource> ();
		audio_gold = GameObject.FindGameObjectWithTag ("Door_gold").GetComponent<AudioSource> ();
		door_red_anim = GameObject.FindGameObjectWithTag ("door_red_anim").GetComponent<Animator> ();
		door_gold_anim = GameObject.FindGameObjectWithTag ("door_gold_anim").GetComponent<Animator> ();
		door_green_anim = GameObject.FindGameObjectWithTag ("door_green_anim").GetComponent<Animator> ();
		door_blue_anim = GameObject.FindGameObjectWithTag ("door_blue_anim").GetComponent<Animator> ();


	}
	

	void Update () {

		if (Input.GetButton ("Cancel") == true && CUI_View == true) {
			Time.timeScale = 1;
			CUI.enabled = false;
			CUI_View = false;
		}


		//Tür ROT aufschließen
		if (Input.GetButton ("Aktivieren") && inTrigger_red == true && Variablen.keyCount_red == true) {
			audio_red.Play ();
			Variablen.keyCount--;
			Variablen.keyCount_red = false;
			door_red_anim.enabled = true;
		} 
			 

		//Tür GOLD aufschließen
		if (Input.GetButton ("Aktivieren") && inTrigger_gold == true && Variablen.keyCount_gold == true) {
			audio_gold.Play ();
			Variablen.keyCount--;
			Variablen.keyCount_gold = false;
			door_gold_anim.enabled = true;
		} 

		//Tür GRÜN aufschließen
		if (Input.GetButton ("Aktivieren") && inTrigger_green == true && Variablen.keyCount_green == true) {
			audio_green.Play ();
			Variablen.keyCount--;
			Variablen.keyCount_green = false;
			door_green_anim.enabled = true;
		}

		//Tür BLAU aufschließen
		if (Input.GetButton ("Aktivieren") && inTrigger_blue == true && Variablen.keyCount_blue == true) {
			audio_blue.Play ();
			Variablen.keyCount--;
			Variablen.keyCount_blue = false;
			door_blue_anim.enabled = true;
		}

	}


	void OnTriggerEnter2D(Collider2D other) {


		// Textfeld aktivieren bei Betreten
		if(other.gameObject.tag == "Press") {
			textfield.text = "Press E";
			textfield.enabled = true;
		}

		if(other.gameObject.tag == "key_red" || other.gameObject.tag == "key_gold" || other.gameObject.tag == "key_green"|| other.gameObject.tag == "key_blue") {
			textfield.enabled = true;
			textfield.text="Press E";
		}


		//In TürBereich
		if (other.gameObject.tag == "Door_red") {
			inTrigger_red = true;
		}

		if (other.gameObject.tag == "Door_gold") {
			inTrigger_gold = true;
		}

		if (other.gameObject.tag == "Door_blue") {
			inTrigger_blue = true;
		}

		if (other.gameObject.tag == "Door_green") {
			inTrigger_green = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		//Textfeld deaktiveren beim Verlassen
		if (other.tag == "Press") {
			textfield.enabled = false;
		}

		if(other.gameObject.tag == "key_red" || other.gameObject.tag == "key_gold" || other.gameObject.tag == "key_green" || other.gameObject.tag == "key_blue") {
			textfield.enabled = false;
		}


		//Ausserhalb TürBereich
		if (other.gameObject.tag == "Door_red") {
			inTrigger_red = false;
		}

		if (other.gameObject.tag == "Door_gold") {
			inTrigger_gold = false;
		}

		if (other.gameObject.tag == "Door_green") {
			inTrigger_green = false;
		}

		if (other.gameObject.tag == "Door_blue") {
			inTrigger_blue = false;
		}
	}


	void OnTriggerStay2D(Collider2D other){


		//AKTE1
		if(other.gameObject.tag == "Akte1" && Input.GetButton("Lesen")) {
			CUI_View = true;
			Destroy (other.gameObject);
			CUI_Info.text = "Hallo ich bin die Info";
			CUI.enabled = true;
			Time.timeScale = 0;
		}

		//AKTE2
		if(other.gameObject.tag == "Akte2" && Input.GetButton("Lesen")) {
			CUI_View = true;
			Destroy (other.gameObject);
			CUI_Info.text = "Testakte";
			CUI.enabled = true;
			Time.timeScale = 0;
		}


		//collect key
		if (Input.GetButton("Aktivieren")) {
			switch(other.gameObject.tag) {
			case "key_blue":
				Variablen.keyCount++;
				Variablen.keyCount_blue = true;
				Destroy (other.gameObject);
				break;
			case "key_red":
				Variablen.keyCount++;
				Variablen.keyCount_red = true;
				Destroy (other.gameObject);
				break;
			case "key_gold":
				Variablen.keyCount++;
				Variablen.keyCount_gold = true;
				Destroy (other.gameObject);
				break;
			case "key_green":
				Variablen.keyCount++;
				Variablen.keyCount_green = true;
				Destroy (other.gameObject);
				break;
			}
		}
	}


}
