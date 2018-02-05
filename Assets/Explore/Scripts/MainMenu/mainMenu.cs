using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {

	// Объекты регулировки настроек
	[Header("General Options")]
	public Slider music_volume;
	public AudioMixer music_mixer; 
	public Slider sfx_volume;
	public AudioMixer sfx_mixer; 
	public Slider ambient_volume;
	public AudioMixer ambient_mixer; 
	public Toggle subtitles_toggle;
	public Toggle autosave_toggle;
	public Toggle console_toggle;
	[Header("Video Options")]
	public Dropdown resolution_dropdown;
	Resolution[] resolutions;
	public Toggle fullscreen_toggle;
	public Toggle vsync_toggle;
	public Slider zoom_slider;
	public Dropdown quality_dropdown;
	public Toggle particles_toggle;
	[Header("Language")]
	public Dropdown all_lang_dropdown;
	[Header("Other")]
	public GameObject particles_1;
	public static int charapterSelect;
	public Text game_ver;

	void Start() {
		// MUSIC
		music_volume.value = PlayerPrefs.GetFloat ("music_volume");
		// SFX
		sfx_volume.value = PlayerPrefs.GetFloat ("sfx_volume");
		// AMBIENT
		ambient_volume.value = PlayerPrefs.GetFloat ("ambient_volume");
		// RESOLUTION
		resolutions = Screen.resolutions;
		resolution_dropdown.ClearOptions();

		List<string> options = new List<string>();
		int currentResolutionIndex = 0;
		for (int i = 0; i < resolutions.Length; i++) {
			string option = resolutions[i].width + " x " + resolutions[i].height;
			options.Add (option);

			if (resolutions [i].width == Screen.currentResolution.width &&
			    resolutions [i].height == Screen.currentResolution.height &&
			    !PlayerPrefs.HasKey ("resolution")) {
				currentResolutionIndex = i;
			} else {
				currentResolutionIndex = PlayerPrefs.GetInt ("resolution");
			}
		}

		resolution_dropdown.AddOptions (options);
		resolution_dropdown.value = currentResolutionIndex;
		resolution_dropdown.RefreshShownValue ();
		// SUBTITLES
		if (PlayerPrefs.GetInt("subtitles") == 0) {
			subtitles_toggle.isOn = false;
		}
		if (PlayerPrefs.GetInt("subtitles") == 1) {
			subtitles_toggle.isOn = true;
		}
		// AUTOSAVE
		if (PlayerPrefs.GetInt("autosave") == 0) {
			autosave_toggle.isOn = false;
		}
		if (PlayerPrefs.GetInt("autosave") == 1) {
			autosave_toggle.isOn = true;
		}
		// CONSOLE
		if (PlayerPrefs.GetInt("console") == 0) {
			console_toggle.isOn = false;
		}
		if (PlayerPrefs.GetInt("console") == 1) {
			console_toggle.isOn = true;
		}
		// V-SYNC
		if (PlayerPrefs.GetInt("vsync") == 0) {
			vsync_toggle.isOn = false;
		}
		if (PlayerPrefs.GetInt("vsync") == 1) {
			vsync_toggle.isOn = true;
		}
		// FULLSCREEN
		if (PlayerPrefs.GetInt("fullscreen") == 0) {
			fullscreen_toggle.isOn = false;
		}
		if (PlayerPrefs.GetInt("fullscreen") == 1) {
			fullscreen_toggle.isOn = true;
		}
		// ZOOM
		zoom_slider.value = PlayerPrefs.GetFloat("zoom");
		// QUALITY
		quality_dropdown.value = PlayerPrefs.GetInt("quality_lvl");
		// PARTICLES
		if (PlayerPrefs.GetInt("particles") == 0) {
			particles_toggle.isOn = false;
		}
		if (PlayerPrefs.GetInt("particles") == 1) {
			particles_toggle.isOn = true;
		}

		// GAME VERSION
		game_ver.text = "Explore v" + Application.version;
	}

	public void play () {
		if (charapterSelect >= 1) {
			SceneManager.LoadScene("Loading");
		}
		if (charapterSelect == 0) {
			SceneManager.LoadScene("CharapterSelect");
		}
	}

	public void SetVolumeMusic (float volume) {
		music_mixer.SetFloat ("music_volume", volume);
		PlayerPrefs.SetFloat("music_volume", volume);
	}
	public void SetVolumeSfx (float volume) {
		sfx_mixer.SetFloat ("sfx_volume", volume);
		PlayerPrefs.SetFloat("sfx_volume", volume);
	}
	public void SetVolumeAmbient (float volume) {
		ambient_mixer.SetFloat ("ambient_volume", volume);
		PlayerPrefs.SetFloat("ambient_volume", volume);
	}

	public void SetResolution (int resolutionIndex) {
		Resolution resolution = resolutions [resolutionIndex];
		Screen.SetResolution (resolution.width, resolution.height, fullscreen_toggle);
		PlayerPrefs.SetInt("resolution", resolutionIndex);
	}

	public void lang_english () {
		all_lang_dropdown.value = 0;
	}
	public void lang_russia () {
		all_lang_dropdown.value = 1;
	}
	public void lang_china () {
		//
	}
	public void lang_french () {
		//
	}

	public void quit () {
		Application.Quit();
	}

	public void del_progress () {
		PlayerPrefs.DeleteAll();
	}

	void Update() {
		// Обработка настроек
		// SUBTITLES
		if (subtitles_toggle.isOn) {
			PlayerPrefs.SetInt("subtitles", 1);
		}
		if (!subtitles_toggle.isOn) {
			PlayerPrefs.SetInt("subtitles", 0);
		}
		// AUTOSAVE
		if (autosave_toggle.isOn) {
			PlayerPrefs.SetInt("autosave", 1);
		}
		if (!autosave_toggle.isOn) {
			PlayerPrefs.SetInt("autosave", 0);
		}
		// CONSOLE
		if (console_toggle.isOn) {
			PlayerPrefs.SetInt("console", 1);
		}
		if (!console_toggle.isOn) {
			PlayerPrefs.SetInt("console", 0);
		}
		// V-SYNC
		if (vsync_toggle.isOn) {
			QualitySettings.vSyncCount = 1;
			PlayerPrefs.SetInt("vsync", 1);
		}
		if (!vsync_toggle.isOn) {
			QualitySettings.vSyncCount = 0;
			PlayerPrefs.SetInt("vsync", 0);
		}
		// FULLSCREEN
		if (fullscreen_toggle.isOn) {
			PlayerPrefs.SetInt("fullscreen", 1);
			Screen.fullScreen = true;
		}
		if (!fullscreen_toggle.isOn) {
			PlayerPrefs.SetInt("fullscreen", 0);
			Screen.fullScreen = false;
		}
		// ZOOM
		PlayerPrefs.SetFloat("zoom", zoom_slider.value);
		// QUALITY
		if (quality_dropdown.value == 0) {
			QualitySettings.SetQualityLevel (0);
			PlayerPrefs.SetInt("quality_lvl", 0);
		}
		if (quality_dropdown.value == 1) {
			QualitySettings.SetQualityLevel (0);
			PlayerPrefs.SetInt("quality_lvl", 1);
		}
		if (quality_dropdown.value == 2) {
			QualitySettings.SetQualityLevel (1);
			PlayerPrefs.SetInt("quality_lvl", 2);
		}
		// PARTICLES
		if (particles_toggle.isOn) {
			PlayerPrefs.SetInt("particles", 1);
			particles_1.SetActive (true);
		}
		if (!particles_toggle.isOn) {
			PlayerPrefs.SetInt("particles", 0);
			particles_1.SetActive (false);
		}

		// New game or continue
		charapterSelect = PlayerPrefs.GetInt("Char");
	}
}
