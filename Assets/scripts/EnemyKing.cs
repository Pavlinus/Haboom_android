using UnityEngine;
using System.Collections;

public class EnemyKing : Enemy {
	bool isDamaged = false;

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag.Equals ("Bullet") && !isDamaged) {
			Bullet bullet = collider.gameObject.GetComponent<Bullet> ();
			
			// If enemy striked by same color bullet
			if (bullet.GetItemColor ().Equals (color)) {
				GameManager.totalScore += score;

				IncreaseColorCount ();
				isDamaged = true;

				// Icrease collider size to destroy near enemies
				GetComponent<BoxCollider2D>().size = new Vector2(10, 10);
				GetComponent<SpriteRenderer>().enabled = false;

				Destroy (gameObject, 2f);
			}
		} else if (collider.tag.Equals ("Tube")) {
			if(!isDamaged) {
				gameManager.GetComponent<GameOverMenu> ().SetComponentsState (true);
				StartCoroutine(ShowStatisticsScene());
				GameManager.isGameOver = true;
			}
		}
	}
}
