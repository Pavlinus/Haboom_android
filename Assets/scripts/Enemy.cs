using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public ColorType.ItemColor color;
	public int score;

	GameObject gameManager;

	void Start() {
		gameManager = GameObject.FindGameObjectWithTag ("GameManager");
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag.Equals ("Bullet")) {
			Bullet bullet = collider.gameObject.GetComponent<Bullet> ();

			// If enemy striked by same color bullet
			if (bullet.GetItemColor ().Equals (color)) {
				GameManager.totalScore += score;

				IncreaseColorCount ();
				Destroy (gameObject);
			}
		
		} else if (collider.tag.Equals ("Tube")) {
			gameManager.GetComponent<GameOverMenu> ().SetComponentsState (true);
			GameManager.isGameOver = true;
			//Time.timeScale = 0f;
			StartCoroutine(ShowStatisticsScene());
		} else if (collider.tag.Equals ("DestroyArea")) {
			Destroy (gameObject);
		}
	}

	IEnumerator ShowStatisticsScene() {
		yield return new WaitForSeconds (2f);
		Application.LoadLevel (2);
	}

	// Calculates number of striked qubes
	void IncreaseColorCount() {
		switch (color) {
		case ColorType.ItemColor.BLUE:
			GameManager.blueEnemies++;
			break;

		case ColorType.ItemColor.GREEN:
			GameManager.greenEnemies++;
			break;

		case ColorType.ItemColor.ORANGE:
			GameManager.orangeEnemies++;
			break;

		case ColorType.ItemColor.RED:
			GameManager.redEnemies++;
			break;
		}
	}
}
