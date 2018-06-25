//	Importierte Klassen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spieler : MonoBehaviour {

	//	Ganz zum Anfang wird eine Instanz dieser Klasse erzeugt
	#region Singleton
	public static Spieler instance;
	void Awake(){
		instance = this;
	}
	#endregion

	//	Benötigte Variablen und Objekte werden erstellt
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

	//	Wird einmaling und als erstes beim Aufrufen des Scripts ausgeführt
	void Start () {

		//	Variablen und Objekte werden initialisiert
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

	//	Methode um Probleme mit dem Pausen-Menü zu verhindern
	IEnumerator BlockPause() {
		Variablen.allowPause = false;
		yield return new WaitForSeconds (0.1f);
		Variablen.allowPause = true;
	}

	// 	Wird einmal pro Bildaktualisierung aufgerufen
	void Update () {

		//	Schließen einer Collectable-Anzeige
		if (Input.GetButtonDown("Cancel") == true && CUI_View == true) {
			CUI_View = false;
			CUI.enabled = false;
			Time.timeScale = 1;
			StartCoroutine (BlockPause ());
		}


		//rote Tür aufschließen
		if (Input.GetButtonDown("Aktivieren") && inTrigger_red == true && Variablen.keyCount_red == true) {
			audio_red.Play ();
			Variablen.keyCount_red = false;
			door_red_anim.enabled = true;
			Inventory.instance.DrawInventory (1, false);
		} 
			 

		//goldene Tür aufschließen
		if (Input.GetButtonDown("Aktivieren") && inTrigger_gold == true && Variablen.keyCount_gold == true) {
			audio_gold.Play ();
			Variablen.keyCount_gold = false;
			door_gold_anim.enabled = true;
			Inventory.instance.DrawInventory (2, false);
		} 

		//grüne Tür aufschließen
		if (Input.GetButtonDown("Aktivieren") && inTrigger_green == true && Variablen.keyCount_green == true) {
			audio_green.Play ();
			Variablen.keyCount_green = false;
			door_green_anim.enabled = true;
			Inventory.instance.DrawInventory (3, false);
		}

		//blaue Tür aufschließen
		if (Input.GetButtonDown("Aktivieren") && inTrigger_blue == true && Variablen.keyCount_blue == true) {
			audio_blue.Play ();
			Variablen.keyCount_blue = false;
			door_blue_anim.enabled = true;
			Inventory.instance.DrawInventory (0, false);
		}
	}

	// 	Wird aufgerufen, wenn der Trigger des Spieler-Objekts mit einem anderen kollidiert
	void OnTriggerEnter2D(Collider2D other) {

		//	Jumppad-Ton wird abgespielt
		if (other.gameObject.tag == "Jumppad") {
			audio_jumppad.Play ();
		}


		//	Hilfstext aktivieren
		if(other.gameObject.tag == "Press") {
			textfield.text = "Press E";
			textfield.enabled = true;
		}

		//	Hilfstext aktivieren
		if(other.gameObject.tag == "key_red" || other.gameObject.tag == "key_gold" || other.gameObject.tag == "key_green"|| other.gameObject.tag == "key_blue") {
			textfield.enabled = true;
			textfield.text="Press E";
		}


		//	Wenn der Spieler auf einem Schlüssel steht
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

	// 	Wird aufgerufen, wenn ein Objekt den Trigger des Spieler-Objekts verlässt
	void OnTriggerExit2D(Collider2D other)
	{
		//	Hilfstext deaktiveren
		if (other.tag == "Press") {
			textfield.enabled = false;
		}

		//	Wenn der Spieler vom Schlüssel herunter geht
		if(other.gameObject.tag == "key_red" || other.gameObject.tag == "key_gold" || other.gameObject.tag == "key_green" || other.gameObject.tag == "key_blue") {
			textfield.enabled = false;
		}
			
		//	Wenn der Spieler den Türbereich verlässt
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

	// 	Wird aufgerufen, wenn ein Objekt auf dem Trigger des Spieler-Objekts steht
	void OnTriggerStay2D(Collider2D other){

		//	Falls es Akte1 ist
		if(other.gameObject.tag == "Akte1" && Input.GetButtonDown("Lesen")) {
			CUI_View = true;
			Destroy (other.gameObject);
			CUI_Info.text = "Bericht 72465 Testlauf Subjekt 8****";
			CUI_Text.text = "-Subjekt zeigt fortgeschrittene Umgebungserkennung nach Initialisierung\n-Motorische Funktionen **********\n-9:42 Subjekt betritt den Testbereich 1\n-******* realisiert ******** *** ******** *** ******** auf *** Zustand\n-10:10 Subjekt betritt Testbereich 2\n-Erwartungen im physikalischen Test übertroffen\n-Subjekt 8**** tritt in Konfrontation mit ***je** *****\n-11:33 Subjekt betritt Testbereich 3\n-12:00 20.04.**** Subjekt 8**** terminiert";
			CUI.enabled = true;
			Time.timeScale = 0;
		}

		//	Falls es Akte2 ist
		if(other.gameObject.tag == "Akte2" && Input.GetButtonDown("Lesen")) {
			CUI_View = true;
			Destroy (other.gameObject);
			CUI_Info.text = "Die Problematik Klonen" +
				"Auszug aus dem Kapitel: Werkzeug der Evolution";
			CUI_Text.text = "…\nDa eben genau dieses Werkzeug beim Erstellen von Klonen entfällt, unter der Annahme der Vorgang wurde wissenschaftlich korrekt und unter angemessenen Sicherheitsmaßnahmen durchgeführt, entwickelt sich automatisch ein Problem bezüglich der Anpassung an neue Umgebungsvariablen. Der „perfekte“ Klon stellt eine 100%ige Kopie des Lebewesens welches als Ausgangsmaterial dient dar. Ist besagter Klon nun einer veränderten Umgebung ausgesetzt, kann eine Anpassung an diese nur durch Umstellung von Lebensart oder ,beispielsweise im Falle des Homo Sapiens, durch Entwicklung neuer Werkzeuge o.ä. statt finden. Diese Anpassung ist allerdings nicht permanent und kann nur durch aufwendiges Lernen und Weitergabe von Wissen an die nächste Generation erhalten werden. Ein „fehlerhaftes“ Lebewesen kann sich allerdings, unter Zusammentreffen der richtigen Umstände, dauerhaft und für Nachfolgende Generationen anpassen. Lebewesen die an der Spitze ihrer respektiven Nahrungskette stehen, haben in ihrer Evolution in der Regel mehr Fehler erfahren als andere. Fehler die sie in den jeweiligen Umgebungen favorisieren.  Der Vorteil von Klonen ohne Fortpflanzung und bei reduzierter Inkubationszeit den Erhalt einer Spezies zu ermöglichen, trifft also immer auf das Problem das entweder jegliche Form von Evolution im Keim erstickt wird, oder „Fehler“ bzw. Anpassungen am genetischen Code erzwungen werden müssen. Dies führt zu zusätzlichen benötigten Mengen von Biokompomenten sowie höherer Verbrauch des womöglich wichtigsten Faktors dieser Diskussion: Zeit.\n..."; 
			CUI.enabled = true;
			Time.timeScale = 0;
		}
			
		//	Falls es Akte2 ist
		if(other.gameObject.tag == "Akte3" && Input.GetButtonDown("Lesen")) {
			CUI_View = true;
			Destroy (other.gameObject);
			CUI_Info.text = "Bericht 72470 Subjektreihe 8" +
				"Auszug aus dem Kapitel: Werkzeug der Evolution";
			CUI_Text.text = "-Alle überlebenden Subjekte der Gruppe 8 wurden planmäßig terminiert\n-27 Subjekte erreichten die letzte Testphase, davon 9 erfolgreiche Abschlüsse\n-12 Subjekte realisierten die Natur der Tests und ihrer Umgebung\n-2 Subjekte der vorher angesprochenen Gruppe begangen Suizid in Anbetracht der Situation\n-37 Subjekte verstarben in Testbereich 1\n-25 Subjekte verstarben in Testbereich 2\n-19 Subjekte verstarben in Testbereich 3\n-Folgende Testbereiche detailliert im Einzelbericht: 4-10\n-Fortschritt konnte sowohl im motorischen als auch rezeptuellen Bereich verzeichnet werden (siehe Detailbericht)\n-verbliebene Biokomponenten an Wiederverwertung übermittelt\n-Tanks und Testbereiche werden für Gruppe 9 gereinigt\n-Klonprozess Gruppe 9 erfolgreich initiiert\n-Testbeginn Gruppe 9 planmäßig 30.07.****\n-Testszenario für Gruppe 9: Fehler im System – Ausbruch Subjekt"; 
			CUI.enabled = true;
			Time.timeScale = 0;
		}

		//	Falls es ein Knopf ist
		if (Input.GetButtonDown ("btn") && other.gameObject.tag == "button") {
			Debug.Log ("btn gedrückt!");
			btn_collider.enabled = false;
		} 

		//	Falls es ein Objekt zum zerstören ist
		if (Input.GetButtonDown ("btn") && other.gameObject.tag == "destroy") {
			Destroy (other.gameObject);
		} 
			
		//	Falls der Aktivieren-Knopf gedrückt wurde
		if (Input.GetButtonDown("Aktivieren")) {

			//	Wird zurückgegeben, falls keine Schlüsselkarte vorliegt (exit-code für Inventory-Klasse)
			byte num = 255;

			//	Falls doch eine Schlüsselkarte vorliegt wird der jeweilige Code der Karte (num) mit übergeben
			//	So kann in der Klasse Inventory rekonstruiert werden, auf welchem Schlüssel der Spieler steht
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

			//	Instanz von Inventory wird erzeugt und dort befindliche DrawInventory wird mit entsprechenden Parametern aufgerufen
			Inventory.instance.DrawInventory (num, true);
		}
	}
}