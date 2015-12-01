using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public ParticleSystem particles;
	public ColorType.ItemColor color;
	public int score;

	protected GameObject gameManager;

	void Start() {
		gameManager = GameObject.FindGameObjectWithTag ("GameManager");
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag.Equals ("Bullet")) {
			Bullet bullet = collider.gameObject.GetComponent<Bullet> ();

			// If enemy striked by same color bullet
			if (bullet.GetItemColor ().Equals (color)) {
				GameManager.totalScore += score;

				// Deactivate bullet object
				collider.gameObject.GetComponent<Bullet>().DisableObject();

				IncreaseColorCount ();
				Destroy (gameObject);
			}

			// Deactivate bullet object
			collider.gameObject.GetComponent<Bullet>().DisableObject();
			
			PlayCollisionParticles();
		} else if (collider.tag.Equals ("Tube")) {
			StartCoroutine(ShowGameOver());
			StartCoroutine (ShowStatisticsScene ());
			GameManager.isGameOver = true;
		} else if (collider.tag.Equals ("DestroyArea")) {
			Destroy (gameObject);
		} else if (collider.tag.Equals ("EnemyKing")) {
			GameManager.totalScore += score;

			PlayCollisionParticles();
			IncreaseColorCount ();
			Destroy (gameObject);
		}
	}

	protected void PlayCollisionParticles() {
		ParticleSystem pSystem;
		Vector2 spawnPoint;
		
		spawnPoint = new Vector2 (transform.position.x, 
		                          transform.position.y);
		
		pSystem = Instantiate (particles, 
		                       spawnPoint, 
		                       Quaternion.identity) as ParticleSystem;
		
		Destroy (pSystem.gameObject, 2.5f);
	}

	protected IEnumerator ShowGameOver() {
		yield return new WaitForSeconds (0.8f);
		gameManager.GetComponent<GameOverMenu> ().SetComponentsState (true);
	}

	protected IEnumerator ShowStatisticsScene() {
		yield return new WaitForSeconds (6f);
		Application.LoadLevel (2);
	}

	// Calculates number of striked qubes
	protected void IncreaseColorCount() {
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
