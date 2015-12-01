using UnityEngine;
using System.Collections;

public class ItemsSpawn : MonoBehaviour {

	public GameObject[] SpawnPoints;
	public GameObject[] enemies;
	public GameObject[] enemiesKing;
	
	bool[] enemyKing;

	void Start() {
		enemyKing = new bool[enemies.Length];
		SpawnItems ();
	}

	void SpawnItems() {
		for (int i = 0; i < enemies.Length; i++) {
			StartCoroutine (StartSpawnAt(i));
		}

		StartCoroutine (AccessToEnemyKing());
	}

	/// <summary>
	/// Coroutine for spawning enemies
	/// </summary>
	/// <returns>The <see cref="System.Collections.IEnumerator"/>.</returns>
	/// <param name="index">Index.</param>
	IEnumerator StartSpawnAt(int index) {
		while(true) {
			float timeWait = Random.Range (1.5f, 3f);
			GameObject spawnItem = enemies[index];

			// If enemy king is available to spawn
			if(enemyKing[index]) {
				spawnItem = enemiesKing[index];
			}

			yield return new WaitForSeconds(timeWait);

			// If game process is running
			if(!GameManager.inPause && !GameManager.isGameOver) {
				Instantiate (spawnItem, SpawnPoints [index].transform.position,
				             Quaternion.identity);
			}
		}
	}

	/// <summary>
	/// Makes `Enemy King` available to spawn
	/// </summary>
	/// <returns>The to enemy king.</returns>
	IEnumerator AccessToEnemyKing() {
		while (true) {
			int index = Random.Range(0, enemies.Length);
			float timeWait = Random.Range(10, 15);

			// If game process is running
			if(!GameManager.inPause && !GameManager.isGameOver) {
				continue;
			}

			yield return new WaitForSeconds(timeWait);

			for(int i = 0; i < enemyKing.Length; i++) {
				enemyKing[i] = false;
			}

			enemyKing[index] = true;
		}
	}
}
