using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {

	public Text TimerText;
	public int playtime = 0;
	private int seconds = 0;
	private int minutes = 0;
	private int hours = 0;

	public bool TimerSettings_sec;
	public bool TimerSettings_min;
	public bool TimerSettings_min_sec;
	public bool TimerSettings_h;

	void Start () {
		playtime = PlayerPrefs.GetInt("PlayedTime");
		StartCoroutine ("Timer");
	}

	private IEnumerator Timer() {
		while (true) {
			yield return new WaitForSeconds(1);
			playtime +=1;
			seconds = (playtime % 60);
			minutes = (playtime / 60) % 60;
			hours = (playtime / 3600) % 24;
		}
	}

	void Update () {
		PlayerPrefs.SetInt("PlayedTime", playtime);
		// Selected Timer Settings
		if (TimerSettings_sec) {
			TimerText.text = "Played: " +  seconds.ToString () + "s";
		}
		if (TimerSettings_min) {
			TimerText.text = "Played: " +  minutes.ToString () + "m";
		}
		if (TimerSettings_min_sec) {
			TimerText.text = "Played: " + minutes.ToString () + "m " + seconds.ToString () + "s";
		}
		if (TimerSettings_h) {
			TimerText.text = "Played: " +  hours.ToString () + "h";
		}
	}
}
