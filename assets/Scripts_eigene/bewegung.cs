using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bewegung : MonoBehaviour {


	private Vector3 startPos;
	private Vector4 newPos;

	public float speed = 10f;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		newPos = startPos;
		newPos.x = newPos.x + Mathf.PingPong (Time.time * speed, 40) ;

		transform.position = newPos;
	}
}
