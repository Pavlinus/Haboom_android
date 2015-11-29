using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public ColorType.ItemColor color;
	public ParticleSystem particles;

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag.Equals ("Enemy") || 
		    collider.tag.Equals ("EnemyKing")) {

			gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			gameObject.GetComponent<CircleCollider2D> ().enabled = false;

			PlayCollisionParticles();
		}
	}

	void PlayCollisionParticles() {
		ParticleSystem pSystem;
		Vector2 spawnPoint;
		float colliderRadius = GetComponent<CircleCollider2D> ().radius;
		
		spawnPoint = new Vector2 (transform.position.x + colliderRadius / 2, 
		                          transform.position.y);

		pSystem = Instantiate (particles, 
		                       spawnPoint, 
		                       Quaternion.identity) as ParticleSystem;
		
		Destroy (pSystem.gameObject, 2.5f);
	}

	public ColorType.ItemColor GetItemColor() {
		return color;
	}
}
