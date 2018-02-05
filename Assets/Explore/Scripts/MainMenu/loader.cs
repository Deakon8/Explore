using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loader : MonoBehaviour {

	[Header("Loading Visuals")]
	public Image fadeOverlay;
	public GameObject LoadingIcon;
	public GameObject TextTips;

	[Header("Timing Settings")]
	public float LoadingIconSpeed = 1.0f;
	public float waitOnLoadEnd = 0.25f;
	public float fadeDuration = 0.25f;

	[Header("Loading Settings")]
	public LoadSceneMode loadSceneMode = LoadSceneMode.Single;
	public ThreadPriority loadThreadPriority;

	[Header("Other")]
	public AudioListener audioListener;
	int message = 0;

	AsyncOperation operation;
	Scene currentScene;

	public static int sceneToLoad = 3;

	public static void LoadScene(int levelNum) {				
		Application.backgroundLoadingPriority = ThreadPriority.High;
		sceneToLoad = levelNum;
		SceneManager.LoadScene("VoxelMap");
	}

	void Start() {
		message = Random.Range(1,6);
		if (sceneToLoad < 0)
			return;

		fadeOverlay.gameObject.SetActive(true); // Наш фейд оверлей
		currentScene = SceneManager.GetActiveScene();
		StartCoroutine(LoadAsync(sceneToLoad));
	}

	void Update() {
		if(message == 1)
			TextTips.GetComponent<Text>().text = "DON'T FORGET: THE HANDBRAKE CAN HELP INITIATE A DRIFT.";
		if(message == 2)
			TextTips.GetComponent<Text>().text = "WHEN LEARNING TO DRIFT, USE AS LITTLE THROTTLE AND STEERING AS POSSIBLE.";
		if(message == 3)
			TextTips.GetComponent<Text>().text = "THE ONE WHO FINISHES FIRST, PROBABLY WASN'T DRIFTING ENOUGH.";
		if(message == 4)
			TextTips.GetComponent<Text>().text = "PLEASE HOON RESPONSIBLY.";
		if(message == 5)
			TextTips.GetComponent<Text>().text = "DON'T BE AFRAID TO USE THE BRAKES IF YOU'RE APPROACHING A CURVE TOO FAST.";

		LoadingIcon.transform.Rotate(0,0,-LoadingIconSpeed);
	}

	private IEnumerator LoadAsync(int levelNum) {
		yield return null; 
		yield return new WaitForSeconds(0.5f);
		FadeIn();
		StartOperation(levelNum);

		while (DoneLoading() == false) {
			yield return null;
		}

		if (loadSceneMode == LoadSceneMode.Additive)
			audioListener.enabled = false;

		yield return new WaitForSeconds(waitOnLoadEnd);

		FadeOut();

		yield return new WaitForSeconds(fadeDuration);

		if (loadSceneMode == LoadSceneMode.Additive)
			SceneManager.UnloadSceneAsync(currentScene.name);
		else
			operation.allowSceneActivation = true;
	}

	private void StartOperation(int levelNum) {
		Application.backgroundLoadingPriority = loadThreadPriority;
		operation = SceneManager.LoadSceneAsync(levelNum, loadSceneMode);


		if (loadSceneMode == LoadSceneMode.Single)
			operation.allowSceneActivation = false;
	}

	private bool DoneLoading() {
		return (loadSceneMode == LoadSceneMode.Additive && operation.isDone) || (loadSceneMode == LoadSceneMode.Single && operation.progress >= 0.9f); 
	}

	void FadeIn() {
		fadeOverlay.CrossFadeAlpha(0, fadeDuration, true);
	}

	void FadeOut() {
		fadeOverlay.CrossFadeAlpha(1, fadeDuration, true);
	}

}
