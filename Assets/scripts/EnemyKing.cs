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
				GetComponent<BoxCollider2D>().size = new Vector2(12, 12);
				GetComponent<SpriteRenderer>().enabled = false;

				Destroy (gameObject, 2f);
			}

			// Deactivate bullet object
			collider.gameObject.GetComponent<Bullet>().DisableObject();

			PlayCollisionParticles();
		} else if (collider.tag.Equals ("Tube")) {
			if(!isDamaged) {
				StartCoroutine(ShowGameOver());
				StartCoroutine(ShowStatisticsScene());
				GameManager.isGameOver = true;
			}
		} else if (collider.tag.Equals ("DestroyArea")) {
			Destroy (gameObject);
		}
	}

	public bool IsDamaged() {
		return isDamaged;
	}
}
