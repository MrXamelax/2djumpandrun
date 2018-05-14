﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Menu : MonoBehaviour {
	public Transform canvas;

	void Update () {
		if (Input.GetButtonDown ("Pause") && Spieler.CUI_View == false ) 
		{
			Pause ();	
		}
	}

	public void Pause()
	{
		if (canvas.gameObject.activeInHierarchy == false) {
			canvas.gameObject.SetActive (true);
			Time.timeScale = 0;
		} else 
		{
			canvas.gameObject.SetActive (false);	
			Time.timeScale = 1;
		}
	}
}
