using UnityEngine;
using System.Collections;

public class ItemsSpawn : MonoBehaviour {

	public GameObject[] SpawnPoints;
	public GameObject[] items;

	float spawnFreq = 0.1f;
	float lastSpawnTime = 0f;

	void Update () {
		SpawnItems ();
	}

	void SpawnItems() {
		if (lastSpawnTime > spawnFreq) {
			lastSpawnTime = 0f;

			int index = Random.Range (0, SpawnPoints.Length);

			GameObject clone = Instantiate (items[index],
			                                SpawnPoints [index].transform.position,
			                                Quaternion.identity) as GameObject;

			clone.GetComponent<Rigidbody2D>().velocity = new Vector2 (-2f, 0);
		} else {
			lastSpawnTime += Time.deltaTime / 7f;
		}
	}
}
