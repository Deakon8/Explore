using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

	public Transform warpTarget;
	private Transform target;
	private bool triggerEntered = false;

	void Start () {
		target = GameObject.FindWithTag("Player").transform;
	}
	void Update () {
		if(Input.GetButtonDown("use") && triggerEntered)
		{
			target.gameObject.transform.position = warpTarget.position;	
		}
	}
	void OnTriggerEnter2D (Collider2D other) {
		triggerEntered = true;
	}
	void OnTriggerExit2D (Collider2D other) {
		triggerEntered = false;
	}
}
