using UnityEngine;
using System.Collections;

public class GameplayMenuInteraction : MonoBehaviour {

	GameObject gameManager;

	void Start() {
		gameManager = GameObject.FindGameObjectWithTag ("GameManager");
	}

	public void OnResumeClicked() {
		gameManager.GetComponent<GameplayMenus> ().SetComponentsState(false);
		Time.timeScale = 1f;
	}

	public void OnRestartClicked() {
		Time.timeScale = 1f;
		Application.LoadLevel (1);
	}

	public void OnMenuClicked() {
		Time.timeScale = 1f;
		Application.LoadLevel (0);
	}

	public void OnQuitClicked() {
		Application.Quit ();
	}
}
