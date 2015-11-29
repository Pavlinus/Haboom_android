using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	
	public ParticleSystem[] shootParticles;
	ColorControllerUI colorController;
	GameObject bulletSource;

	void Start () {
		GameObject colorControllerObj = GameObject.
			FindGameObjectWithTag ("ColorController");

		bulletSource = GameObject.
			FindGameObjectWithTag ("BulletSource");

		colorController = colorControllerObj.GetComponent<ColorControllerUI> ();
	}

	void PlayShootParticles() {
		ParticleSystem pSystem;
		Vector2 spawnPoint;
		
		spawnPoint = new Vector2 (bulletSource.transform.position.x, 
		                          bulletSource.transform.position.y);
		
		pSystem = Instantiate (shootParticles[ColorControllerUI.curColorIndex], 
		                       spawnPoint,
		                       Quaternion.identity) as ParticleSystem;
		
		Destroy (pSystem.gameObject, 2.5f);
	}

	public void Shoot() {
		GameObject clone;
		clone = Instantiate (colorController.bulletObj[ColorControllerUI.curColorIndex], 
		                     transform.position, 
		                     Quaternion.identity) as GameObject;
		
		clone.GetComponent<Rigidbody2D> ().velocity = new Vector2 (8f, 0f);
		Destroy (clone, 3f);
		
		PlayShootParticles ();
	}
}
