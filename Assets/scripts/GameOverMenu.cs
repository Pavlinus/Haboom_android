using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverMenu : MonoBehaviour {

	public Button restartBtn;
	public Button quitBtn;
	public Image background;
	public Text gameOver;

	GameObject player;
	GameObject bulletSource;

	bool inGameOver;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		bulletSource = GameObject.FindGameObjectWithTag("BulletSource");

		SetComponentsState (false);

		player.GetComponent<WeaponMovement> ().enabled = false;
		bulletSource.GetComponent<Shooting> ().enabled = false;

		inGameOver = false;
	}

	public void SetComponentsState(bool state) {
		restartBtn.GetComponentInChildren<Text> ().enabled = state;
		quitBtn.GetComponentInChildren<Text> ().enabled = state;

		restartBtn.enabled = state;
		quitBtn.enabled = state;
		background.enabled = state;
		gameOver.enabled = state;
		
		player.GetComponent<WeaponMovement> ().enabled = !state;
		bulletSource.GetComponent<Shooting> ().enabled = !state;

		inGameOver = state;
	}

	public bool GameOverMenuIsActive() {
		return inGameOver;
	}
}
