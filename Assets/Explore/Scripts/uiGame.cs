using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class uiGame : MonoBehaviour {

	public Image blackScreen;

	public void Start() {
		StartCoroutine (StarterFade ());
	}
	public IEnumerator StarterFade() {
		blackScreen.CrossFadeAlpha (0.0f, 1.5f, true);
		yield return new WaitForSeconds(1.5f);
		blackScreen.enabled = false;
	}
	public void ExitGame() {
		Application.Quit();
	}
}
