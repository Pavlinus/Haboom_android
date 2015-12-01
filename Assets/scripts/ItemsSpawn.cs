using UnityEngine;
using System.Collections;

public class ItemsSpawn : MonoBehaviour {

	public GameObject[] SpawnPoints;
	public GameObject[] enemies;
	public GameObject[] enemiesKing;
	
	bool[] enemyKing;
	int spawned;

	void Start() {
		enemyKing = new bool[enemies.Length];
		SpawnItems ();
	}

	void Update() {
		if (spawned > 25) {
			int index = Random.Range(0, enemies.Length);

			for(int i = 0; i < enemyKing.Length; i++) {
				enemyKing[i] = false;
			}
			
			enemyKing[index] = true;
			spawned = 0;
		}
	}

	void SpawnItems() {
		for (int i = 0; i < enemies.Length; i++) {
			StartCoroutine (StartSpawnAt(i));
		}
	}

	/// <summary>
	/// Coroutine for spawning enemies
	/// </summary>
	/// <returns>The <see cref="System.Collections.IEnumerator"/>.</returns>
	/// <param name="index">Index.</param>
	IEnumerator StartSpawnAt(int index) {
		while(true) {
			float timeWait = Random.Range (1.5f, 2.5f);
			GameObject spawnItem = enemies[index];

			// If enemy king is available to spawn
			if(enemyKing[index]) {
				spawnItem = enemiesKing[index];
				enemyKing[index] = false;
			}

			yield return new WaitForSeconds(timeWait);

			// If game process is running
			if(!GameManager.inPause && !GameManager.isGameOver) {
				Instantiate (spawnItem, SpawnPoints [index].transform.position,
				             Quaternion.identity);
				spawned += 1;
			}
		}
	}
}
