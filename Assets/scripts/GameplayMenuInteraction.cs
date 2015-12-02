using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameplayMenuInteraction : MonoBehaviour {

	GameObject gameManager;
	GameObject splashScreen;
	SplashScreen sScreen;
	AudioSource audioSource;

	void Start() {
		gameManager = GameObject.FindGameObjectWithTag ("GameManager");
		splashScreen = GameObject.FindGameObjectWithTag ("SplashScreen");

		audioSource = GetComponent<AudioSource> ();
		sScreen = splashScreen.GetComponent<SplashScreen> ();
	}

	public void OnResumeClicked() {
		audioSource.Play ();
		gameManager.GetComponent<GameplayMenus> ().SetComponentsState(false);
	}

	public void OnSoundClicked() {
		audioSource.Play ();
		GetComponent<Sound> ().MuteSoundState (!GameManager.soundOn);
	}

	public void OnRestartClicked() {
		audioSource.Play ();
		sScreen.SetParameter ("splashIn");
		StartCoroutine(LoadLevel (1));
	}

	public void OnMenuClicked() {
		audioSource.Play ();
		GameManager.inPause = false;
		Application.LoadLevel (0);
	}

	public void OnQuitClicked() {
		audioSource.Play ();
		Application.Quit ();
	}

	IEnumerator LoadLevel(int scene) {
		yield return new WaitForSeconds(2.5f);
		Application.LoadLevel (scene);
	}
}
