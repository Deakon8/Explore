using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class selectCharapter : MonoBehaviour {

	public static int charapterSelect = 1;
	public GameObject human_char;
	public GameObject elf_char;
	public GameObject darkelf_char;
	public GameObject orc_char;
	public GameObject dwarf_char;
	[Header("Design")]
	public Image fadeOverlay;
	public float fadeDuration = 0.25f;

	void Start () {
		charapterSelect = PlayerPrefs.GetInt("Char");
		StartCoroutine(FadeIn());
		if (charapterSelect > 0) {
			SceneManager.LoadScene("Loading");
		}
	}
	private IEnumerator FadeIn() {
		fadeOverlay.gameObject.SetActive(true);
		fadeOverlay.CrossFadeAlpha(0, fadeDuration, true);
		yield return new WaitForSeconds(fadeDuration);
		fadeOverlay.gameObject.SetActive(false);
	}
	private IEnumerator Loading() {
		fadeOverlay.gameObject.SetActive(true);
		fadeOverlay.CrossFadeAlpha(0, 0, true);
		fadeOverlay.CrossFadeAlpha(1, fadeDuration, true);
		yield return new WaitForSeconds(fadeDuration);
		SceneManager.LoadScene("Loading");
	}

	void Update () {
		if (charapterSelect <= 0) {
			charapterSelect = 1;
		}
		if (charapterSelect > 5) {
			charapterSelect = 5;
		}
		if (charapterSelect == 1) {
			human_char.SetActive(true);
			elf_char.SetActive(false);
		}
		if (charapterSelect == 2) {
			elf_char.SetActive(true);
			human_char.SetActive(false);
			darkelf_char.SetActive(false);
		}
		if (charapterSelect == 3) {
			darkelf_char.SetActive(true);
			elf_char.SetActive(false);
			orc_char.SetActive(false);
		}
		if (charapterSelect == 4) {
			orc_char.SetActive(true);
			darkelf_char.SetActive(false);
			dwarf_char.SetActive(false);
		}
		if (charapterSelect == 5) {
			dwarf_char.SetActive(true);
			orc_char.SetActive(false);
		}
	}

	public void select_char_left () {
		charapterSelect = charapterSelect-1;
	}
	public void select_char_right () {
		charapterSelect = charapterSelect+1;
	}
	public void finish_select () {
		PlayerPrefs.SetInt("Char", charapterSelect);
		PlayerPrefs.SetInt("Coins", 1);
		PlayerPrefs.SetInt("Silver", 0);
		PlayerPrefs.SetInt("Cooper", 0);
		PlayerPrefs.SetInt("Exp", 0);
		PlayerPrefs.SetInt("Hp", 15);
		PlayerPrefs.SetInt("Mp", 5);
		PlayerPrefs.SetString("Helmet", "helmet_1");
		PlayerPrefs.SetString("Plate", "plate_1");
		PlayerPrefs.SetString("Gloves", "gloves_1");
		PlayerPrefs.SetString("Boots", "boots_1");
		StartCoroutine(Loading());
	}
}
