using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameplayMenus : MonoBehaviour {

	public Button resumeBtn;
	public Button restartBtn;
	public Button quitBtn;
	public Image background;
	public Graphic pauseHeader;

	GameObject player;
	GameObject bulletSource;

	bool inPause;
	
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		bulletSource = GameObject.FindGameObjectWithTag("BulletSource");

		inPause = false;
		SetComponentsState (false);

		player.GetComponent<WeaponMovement> ().enabled = false;
		bulletSource.GetComponent<Shooting> ().enabled = false;
	}

	void Update () {
		if (Input.GetButtonDown ("Escape") && 
		    !GetComponent<HelpMenu>().HelpMenuIsActive() &&
		    !GetComponent<GameOverMenu>().GameOverMenuIsActive()) {

			if(!inPause) {
				Time.timeScale = 0f;
			} else {
				Time.timeScale = 1f;
			}

			SetComponentsState(!inPause);
		}
	}

	public void SetComponentsState(bool state) {
		resumeBtn.GetComponentInChildren<Text> ().enabled = state;
		restartBtn.GetComponentInChildren<Text> ().enabled = state;
		quitBtn.GetComponentInChildren<Text> ().enabled = state;

		resumeBtn.enabled = state;
		restartBtn.enabled = state;
		quitBtn.enabled = state;
		background.enabled = state;

		pauseHeader.GetComponent<Text> ().enabled = state;

		foreach (Image image in pauseHeader.GetComponentsInChildren<Image>()) {
			image.enabled = state;
		}

		player.GetComponent<WeaponMovement> ().enabled = !state;
		bulletSource.GetComponent<Shooting> ().enabled = !state;

		inPause = state;
	}
}
