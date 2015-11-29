using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MoveControllerUI : MonoBehaviour {
	public Image movementImg;

	GameObject player;
	WeaponMovement wMovement;
	float moveDirection;
	Vector3[] rectCorners;
	
	void Start () {		
		player = GameObject.FindGameObjectWithTag ("Player");
		wMovement = player.GetComponent<WeaponMovement> ();

		rectCorners = new Vector3[4];
		movementImg.GetComponent<RectTransform> ().GetWorldCorners (rectCorners);

		moveDirection = 0;
	}

	void Update () {
		Touch[] touches = Input.touches;
		
		for (int i = 0; i < touches.Length; i++) {
			Vector2 touchPos = touches[i].position;
			
			if(InMovementBtnArea(touchPos)) {
				if(touches[i].phase == TouchPhase.Moved) {
					SetMoveDirection(touches[i]);
					wMovement.Move(moveDirection);
				} else if (touches[i].phase == TouchPhase.Stationary) {
					moveDirection = 0;
				}
			} else {
				moveDirection = 0;
			}
		}
	}

	/**
	 * True if touch was made in specific area
	 * */
	bool InMovementBtnArea(Vector2 touchPos) {
		movementImg.GetComponent<RectTransform> ().GetWorldCorners (rectCorners);

		// Movement touch area
		float leftBound = rectCorners [0].x;
		float rightBound = rectCorners [2].x;
		float downBound = rectCorners [0].y;
		float upBound = rectCorners [2].y;
		
		if (touchPos.x > leftBound && touchPos.x < rightBound &&
		    touchPos.y > downBound && touchPos.y < upBound) {
			return true;
		}
		
		return false;
	}

	void SetMoveDirection (Touch touch) {
		if (touch.deltaPosition.y > 0) {
			moveDirection = 1;
		} else if (touch.deltaPosition.y < 0) {
			moveDirection = -1;
		}
	}
}
