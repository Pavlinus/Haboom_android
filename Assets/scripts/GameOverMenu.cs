using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverMenu : MonoBehaviour {

	public Button restartBtn;
	public Button quitBtn;
	public Image background;
	public Text gameOver;
	
	bool inGameOver;

	void Start () {
		SetComponentsState (false);

		inGameOver = false;
	}

	public void SetComponentsState(bool state) {
		//restartBtn.GetComponentInChildren<Text> ().enabled = state;
		//quitBtn.GetComponentInChildren<Text> ().enabled = state;

		restartBtn.enabled = state;
		quitBtn.enabled = state;
		background.enabled = state;
		gameOver.enabled = state;

		inGameOver = state;
	}

	public bool GameOverMenuIsActive() {
		return inGameOver;
	}
}
