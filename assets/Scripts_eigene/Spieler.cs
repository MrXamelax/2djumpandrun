using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spieler : MonoBehaviour {
	
	#region Singleton
	public static Spieler instance;
	void Awake(){
		instance = this;
	}
	#endregion

	private Text textfield;
	private bool inTrigger_blue = false;
	private bool inTrigger_green = false;
	private bool inTrigger_red = false;
	private bool inTrigger_gold = false;
	public bool CUI_View = false;
	private Text CUI_Info;
	private Text CUI_Text;
	private Image CUI_Bild; 
	Canvas CUI;
	AudioSource audio_red;
	AudioSource audio_blue;
	AudioSource audio_green;
	AudioSource audio_gold;
	AudioSource audio_jumppad;
	Animator door_red_anim;
	Animator door_gold_anim;
	Animator door_green_anim;
	Animator door_blue_anim;
	BoxCollider2D btn_collider;

	void Start () {
		textfield = GameObject.FindGameObjectWithTag ("Textfield").GetComponent<Text> ();
		CUI = GameObject.FindGameObjectWithTag ("CUI").GetComponent<Canvas>();
		CUI_Text = GameObject.FindGameObjectWithTag ("CUI_Text").GetComponent<Text>();
		CUI_Info = GameObject.FindGameObjectWithTag ("CUI_Info").GetComponent<Text>();
		audio_jumppad = GameObject.FindGameObjectWithTag ("Jumppad").GetComponent<AudioSource> ();
		audio_red = GameObject.FindGameObjectWithTag ("Door_red").GetComponent<AudioSource> ();
		audio_blue = GameObject.FindGameObjectWithTag ("Door_blue").GetComponent<AudioSource> ();
		audio_green = GameObject.FindGameObjectWithTag ("Door_green").GetComponent<AudioSource> ();
		audio_gold = GameObject.FindGameObjectWithTag ("Door_gold").GetComponent<AudioSource> ();
		door_red_anim = GameObject.FindGameObjectWithTag ("door_red_anim").GetComponent<Animator> ();
		door_gold_anim = GameObject.FindGameObjectWithTag ("door_gold_anim").GetComponent<Animator> ();
		door_green_anim = GameObject.FindGameObjectWithTag ("door_green_anim").GetComponent<Animator> ();
		door_blue_anim = GameObject.FindGameObjectWithTag ("door_blue_anim").GetComponent<Animator> ();
		btn_collider = GameObject.FindGameObjectWithTag ("button").GetComponent<BoxCollider2D> ();


	}

	IEnumerator BlockPause(){
		Variablen.allowPause = false;
		yield return new WaitForSeconds (0.1f);
		Variablen.allowPause = true;
	}

	void Update () {

		if (Input.GetButtonDown("Cancel") == true && CUI_View == true) {
			CUI_View = false;
			CUI.enabled = false;
			Time.timeScale = 1;
			StartCoroutine (BlockPause ());
		}


		//Tür ROT aufschließen
		if (Input.GetButtonDown("Aktivieren") && inTrigger_red == true && Variablen.keyCount_red == true) {
			audio_red.Play ();
			Variablen.keyCount_red = false;
			door_red_anim.enabled = true;
			Inventory.instance.DrawInventory (1, false);
		} 
			 

		//Tür GOLD aufschließen
		if (Input.GetButtonDown("Aktivieren") && inTrigger_gold == true && Variablen.keyCount_gold == true) {
			audio_gold.Play ();
			Variablen.keyCount_gold = false;
			door_gold_anim.enabled = true;
			Inventory.instance.DrawInventory (2, false);
		} 

		//Tür GRÜN aufschließen
		if (Input.GetButtonDown("Aktivieren") && inTrigger_green == true && Variablen.keyCount_green == true) {
			audio_green.Play ();
			Variablen.keyCount_green = false;
			door_green_anim.enabled = true;
			Inventory.instance.DrawInventory (3, false);
		}

		//Tür BLAU aufschließen
		if (Input.GetButtonDown("Aktivieren") && inTrigger_blue == true && Variablen.keyCount_blue == true) {
			Variablen.keyCount_blue = false;
			door_blue_anim.enabled = true;
			Inventory.instance.DrawInventory (0, false);
			audio_blue.Play ();
		}

	}

	void OnTriggerEnter2D(Collider2D other) {



		if (other.gameObject.tag == "Jumppad") {
			audio_jumppad.Play ();
		}


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
		if(other.gameObject.tag == "Akte1" && Input.GetButtonDown("Lesen")) {
			CUI_View = true;
			Destroy (other.gameObject);
			CUI_Info.text = "Bericht 72465 Testlauf Subjekt 8****";
			CUI_Text.text = "-Subjekt zeigt fortgeschrittene Umgebungserkennung nach Initialisierung\n-Motorische Funktionen **********\n-9:42 Subjekt betritt den Testbereich 1\n-******* realisiert ******** *** ******** *** ******** auf *** Zustand\n-10:10 Subjekt betritt Testbereich 2\n-Erwartungen im physikalischen Test übertroffen\n-Subjekt 8**** tritt in Konfrontation mit ***je** *****\n-11:33 Subjekt betritt Testbereich 3\n-12:00 20.04.**** Subjekt 8**** terminiert";
			CUI.enabled = true;
			Time.timeScale = 0;
		}

		//AKTE2
		if(other.gameObject.tag == "Akte2" && Input.GetButtonDown("Lesen")) {
			CUI_View = true;
			Destroy (other.gameObject);
			CUI_Info.text = "Die Problematik Klonen - Prof.Dr.Med. Karsten Sand" +
				"Auszug aus dem Kapitel: Werkzeug der Evolution";
			CUI_Text.text = "…\nDa eben genau dieses Werkzeug beim Erstellen von Klonen entfällt, unter der Annahme der Vorgang wurde wissenschaftlich korrekt und unter angemessenen Sicherheitsmaßnahmen durchgeführt, entwickelt sich automatisch ein Problem bezüglich der Anpassung an neue Umgebungsvariablen. Der „perfekte“ Klon stellt eine 100%ige Kopie des Lebewesens welches als Ausgangsmaterial dient dar. Ist besagter Klon nun einer veränderten Umgebung ausgesetzt, kann eine Anpassung an diese nur durch Umstellung von Lebensart oder ,beispielsweise im Falle des Homo Sapiens, durch Entwicklung neuer Werkzeuge o.ä. statt finden. Diese Anpassung ist allerdings nicht permanent und kann nur durch aufwendiges Lernen und Weitergabe von Wissen an die nächste Generation erhalten werden. Ein „fehlerhaftes“ Lebewesen kann sich allerdings, unter Zusammentreffen der richtigen Umstände, dauerhaft und für Nachfolgende Generationen anpassen. Lebewesen die an der Spitze ihrer respektiven Nahrungskette stehen, haben in ihrer Evolution in der Regel mehr Fehler erfahren als andere. Fehler die sie in den jeweiligen Umgebungen favorisieren.  Der Vorteil von Klonen ohne Fortpflanzung und bei reduzierter Inkubationszeit den Erhalt einer Spezies zu ermöglichen, trifft also immer auf das Problem das entweder jegliche Form von Evolution im Keim erstickt wird, oder „Fehler“ bzw. Anpassungen am genetischen Code erzwungen werden müssen. Dies führt zu zusätzlichen benötigten Mengen von Biokompomenten sowie höherer Verbrauch des womöglich wichtigsten Faktors dieser Diskussion: Zeit.\n..."; 
			CUI.enabled = true;
			Time.timeScale = 0;
		}

		if (Input.GetButtonDown ("btn") && other.gameObject.tag == "button") {
			Debug.Log ("btn gedrückt!");
			btn_collider.enabled = false;

		} 


		//collect key
		if (Input.GetButtonDown("Aktivieren")) {
			byte num = 255;
			switch(other.gameObject.tag) {
			case "key_blue":
				Variablen.keyCount_blue = true;
				Destroy (other.gameObject);
				num = 0;
				break;
			case "key_red":
				Variablen.keyCount_red = true;
				Destroy (other.gameObject);
				num = 1;
				break;
			case "key_gold":
				Variablen.keyCount_gold = true;
				Destroy (other.gameObject);
				num = 2;
				break;
			case "key_green":
				Variablen.keyCount_green = true;
				Destroy (other.gameObject);
				num = 3;
				break;
			}
			Inventory.instance.DrawInventory (num, true);
		}
	}


}
