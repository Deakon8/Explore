using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTrigger : MonoBehaviour {

	private SpriteRenderer sp;
	private Animator an;

	void Start () {
		sp = GetComponent<SpriteRenderer>();
		an = GetComponent<Animator>();

		an.enabled = false;
		sp.enabled = false;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		an.enabled = true;
		sp.enabled = true;
	}
	void OnTriggerExit2D(Collider2D other)
	{
		an.enabled = false;
		sp.enabled = false;
	}
}
