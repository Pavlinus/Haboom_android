using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameplayMenus : MonoBehaviour {

	public Button resumeBtn;
	public Button restartBtn;
	public Button quitBtn;
	public Image background;
	public Graphic pauseHeader;

	GameObject gameManager;

	void Start () {
		gameManager = GameObject.FindGameObjectWithTag ("GameManager");
		SetComponentsState (false);
	}

	void Update () {
		if (Input.GetButtonDown ("Escape") && 
		    !GameManager.inHelpMenu &&
		    !GameManager.isGameOver) {

			SetComponentsState(!GameManager.inPause);
		}
	}

	public void SetComponentsState(bool state) {
		resumeBtn.GetComponentInChildren<Text> ().enabled = state;
		restartBtn.GetComponentInChildren<Text> ().enabled = state;
		quitBtn.GetComponentInChildren<Text> ().enabled = state;

		resumeBtn.enabled = state;
		resumeBtn.GetComponent<Image> ().enabled = state;
		restartBtn.enabled = state;
		restartBtn.GetComponent<Image> ().enabled = state;
		quitBtn.enabled = state;
		quitBtn.GetComponent<Image> ().enabled = state;
		background.enabled = state;

		pauseHeader.GetComponent<Text> ().enabled = state;

		foreach (Image image in pauseHeader.GetComponentsInChildren<Image>()) {
			image.enabled = state;
		}
		
		GameManager.inPause = state;

		if (!GameManager.inPause) {
			gameManager.GetComponent<AudioSource> ().Play ();
		} else {
			gameManager.GetComponent<AudioSource> ().Pause();
		}
	}
}
