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
		gameManager.GetComponent<GameplayMenus> ().SetComponentsState(false);
	}

	public void OnSoundClicked() {
		GetComponent<Sound> ().MuteSoundState (!GameManager.soundOn);
	}

	public void OnRestartClicked() {
		sScreen.SetParameter ("splashIn");
		StartCoroutine(LoadLevel (1));
	}

	public void OnMenuClicked() {
		GameManager.inPause = false;
		Application.LoadLevel (0);
	}

	public void OnQuitClicked() {
		Application.Quit ();
	}

	IEnumerator LoadLevel(int scene) {
		yield return new WaitForSeconds(2.5f);
		Application.LoadLevel (scene);
	}
}
