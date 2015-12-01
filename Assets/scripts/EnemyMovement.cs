using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	float speed = 1.8f;

	void Update () {
		if (!GameManager.inPause) {
			Move ();
		}
	}

	void Move () {
		float xPos = transform.position.x;
		float yPos = transform.position.y;

		transform.position = new Vector2 (xPos - speed * Time.deltaTime,
		                                  yPos);
	}
}
