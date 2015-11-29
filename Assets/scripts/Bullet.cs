using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public ColorType.ItemColor color;

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag.Equals ("Enemy")) {
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			gameObject.GetComponent<CircleCollider2D> ().enabled = false;
		}
	}

	public ColorType.ItemColor GetItemColor() {
		return color;
	}
}
