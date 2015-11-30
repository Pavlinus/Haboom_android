using UnityEngine;
using System.Collections;

public class Tube : MonoBehaviour {

	public Sprite whiteTube;
	public Sprite whitePlayer;
	public ParticleSystem[] particleCollision;

	GameObject player;
	GameObject bulletSource;

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");
		bulletSource = GameObject.FindGameObjectWithTag("BulletSource");
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag.Equals("Enemy") || collider.tag.Equals("EnemyKing")) {

			// If `Enemy King` was shooted (damaged)
			if(collider.tag.Equals("EnemyKing")) {
				bool damaged = collider.GetComponent<EnemyKing>().IsDamaged();

				if(damaged) {
					return;
				}
			}

			GameObject tubeParticles = GameObject.FindGameObjectWithTag("TubeParticles");
			Destroy(tubeParticles);

			// Change sprites to white type
			player.GetComponent<SpriteRenderer>().sprite = whitePlayer;
			GetComponent<SpriteRenderer>().sprite = whiteTube;

			// Point to spawn collision particles
			float colliderSizeX = GetComponent<BoxCollider2D>().size.x;
			float xAxisPos = transform.position.x + colliderSizeX / 2;
			Vector2 collisionParticlesSpawn = new Vector2(xAxisPos,
			                                              collider.transform.position.y);

			GetComponent<BoxCollider2D>().enabled = false;
			DeactivateScripts();

			ParticleSystem particles;
			particles = Instantiate(particleCollision[ColorControllerUI.curColorIndex],
			                        collisionParticlesSpawn,
			                        Quaternion.identity) as ParticleSystem;
			Destroy(particles.gameObject, 3f);
		}
	}

	void DeactivateScripts() {
		player.GetComponent<WeaponMovement> ().enabled = false;
		bulletSource.GetComponent<Shooting> ().enabled = false;
	}
}
