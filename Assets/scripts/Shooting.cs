using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	
	public ParticleSystem[] shootParticles;
	GameObject colorControllerObj;
	ColorControllerUI colorController;

	void Start () {
		colorControllerObj = GameObject.FindGameObjectWithTag ("ColorController");
		colorController = colorControllerObj.GetComponent<ColorControllerUI> ();
	}

	void Update () {}

	void PlayShootParticles(ParticleSystem shootParticles) {
		shootParticles.playOnAwake = true;
		shootParticles.Play ();
	}

	public void Shoot() {
		GameObject clone;
		clone = Instantiate (colorController.bulletObj[ColorControllerUI.curColorIndex], 
		                     transform.position, 
		                     Quaternion.identity) as GameObject;
		
		clone.GetComponent<Rigidbody2D> ().velocity = new Vector2 (8f, 0f);
		Destroy (clone, 3f);
		
		PlayShootParticles (shootParticles[ColorControllerUI.curColorIndex]);
	}
}
