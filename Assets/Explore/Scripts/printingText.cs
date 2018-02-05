using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class printingText : MonoBehaviour {

	private Text textUI;
	private TextMesh textMesh;
	[Range(0, 0.5f)]
	public float printingSpeed;
	[TextArea(3,10)]
	public string printText;

	void Start () {
		if (this.gameObject.GetComponent<Text>()) {
			textUI = this.gameObject.GetComponent<Text>();
			StartCoroutine (TextUICoroutine (printText));
		}
		if (this.gameObject.GetComponent<TextMesh>()) {
			textMesh = this.gameObject.GetComponent<TextMesh>();
			StartCoroutine (TextMeshCoroutine (printText));
		}
	}

	IEnumerator TextUICoroutine(string text) {
		foreach(char c in text) {
			textUI.text = textUI.text + c;
			yield return new WaitForSeconds(printingSpeed);
		}
	}
	IEnumerator TextMeshCoroutine(string text) {
		foreach(char c in text) {
			textMesh.text = textMesh.text + c;
			yield return new WaitForSeconds(printingSpeed);
		}
	}
}
