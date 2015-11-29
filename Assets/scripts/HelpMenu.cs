using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HelpMenu : MonoBehaviour {

	public Image background;
	public Text subject;
	public Text lmbDescriptionText;
	public Text rmbDescriptionText;
	
	GameObject player;
	GameObject bulletSource;

	bool inHelp;
	
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		bulletSource = GameObject.FindGameObjectWithTag("BulletSource");
		
		SetComponentsState (true);
		Time.timeScale = 0f;
		GameManager.isGameOver = false;
	}

	void Update() {
		if (Input.GetMouseButtonDown (0)) {
			SetComponentsState(false);
			Time.timeScale = 1f;

			enabled = false;
		}
	}

	public void SetComponentsState(bool state) {
		background.enabled = state;
		subject.enabled = state;
		lmbDescriptionText.enabled = state;
		rmbDescriptionText.enabled = state;

		player.GetComponent<WeaponMovement> ().enabled = !state;
		bulletSource.GetComponent<Shooting> ().enabled = !state;

		inHelp = state;
	}

	public bool HelpMenuIsActive() {
		return inHelp;
	}
}
