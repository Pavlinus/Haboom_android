using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HelpMenu : MonoBehaviour {

	public Image background;
	public Text subject;
	public Text lmbDescriptionText;
	public Text rmbDescriptionText;
	public Text movementDescriptionText;

	GameObject gameManager;
	bool inHelp;
	
	void Start () {
		gameManager = GameObject.FindGameObjectWithTag ("GameManager");

		SetComponentsState (true);
		GameManager.isGameOver = false;
	}

	void Update() {
		if (Input.GetMouseButtonDown (0)) {
			SetComponentsState(false);

			// Disable help menu script
			enabled = false;
		}
	}

	public void SetComponentsState(bool state) {
		background.enabled = state;
		subject.enabled = state;
		lmbDescriptionText.enabled = state;
		rmbDescriptionText.enabled = state;
		movementDescriptionText.enabled = state;

		// Deactivate movement and shooting scripts
		gameManager.GetComponent<GameManager> ()
			.SetScriptsActiveState (!state);

		inHelp = state;
	}

	public bool HelpMenuIsActive() {
		return inHelp;
	}
}
