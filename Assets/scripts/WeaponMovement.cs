using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class WeaponMovement : MonoBehaviour {

	float moveSpeed = 12f;
	float topPosition = 3.5f;
	float bottomPosition = -4.9f;

	public void Move(float y) {
		float newYPosition = y * moveSpeed * Time.deltaTime + transform.position.y;

		if (newYPosition > topPosition) {
			newYPosition = topPosition;
		} else if (newYPosition < bottomPosition) {
			newYPosition = bottomPosition;
		}

		Vector2 movement = new Vector2(transform.position.x, 
		                               newYPosition);
		
		transform.position = movement;
	}
}
