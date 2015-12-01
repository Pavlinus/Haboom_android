using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static int totalScore = 0;
	public static int redEnemies = 0;
	public static int blueEnemies = 0;
	public static int greenEnemies = 0;
	public static int orangeEnemies = 0;
	public static bool isGameOver = false;
	public static bool inPause = false; 

	void Start() {
		Input.multiTouchEnabled = true;
		ResetValues ();
	}
 
	public static void ResetValues() {
		totalScore = 0;
		redEnemies = 0;
		blueEnemies = 0;
		greenEnemies = 0;
		orangeEnemies = 0;
	}

	public void SetScriptsActiveState (bool state) {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		GameObject bulletSource = GameObject.FindGameObjectWithTag("BulletSource");

		player.GetComponent<WeaponMovement> ().enabled = state;
		bulletSource.GetComponent<Shooting> ().enabled = state;
		GetComponent<ItemsSpawn> ().enabled = state;
	}
}
