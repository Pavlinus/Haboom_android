using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameplayMenuInteraction : MonoBehaviour {

	GameObject gameManager;
	GameObject splashScreen;
	SplashScreen sScreen;

	void Start() {
		gameManager = GameObject.FindGameObjectWithTag ("GameManager");
		splashScreen = GameObject.FindGameObjectWithTag ("SplashScreen");

		sScreen = splashScreen.GetComponent<SplashScreen> ();
	}

	public void OnResumeClicked() {
		Time.timeScale = 1f;
		gameManager.GetComponent<GameplayMenus> ().SetComponentsState(false);
	}

	public void OnRestartClicked() {
		sScreen.SetParameter ("splashIn");
		StartCoroutine(LoadLevel (1));
	}

	public void OnMenuClicked() {
		LoadLevel (0);
	}

	public void OnQuitClicked() {
		Application.Quit ();
	}

	IEnumerator LoadLevel(int scene) {
		Time.timeScale = 1f;
		yield return new WaitForSeconds(2.5f);
		Application.LoadLevel (scene);
	}
}
