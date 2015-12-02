using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class ShootControllerUI : MonoBehaviour {

	public Image shootingImg;

	GameObject bulletSource;
	Shooting shooting;
	GameObject colorSwitcher;
	ColorControllerUI colorController;

	Vector3[] rectCorners;

	void Start () {
		bulletSource = GameObject.FindGameObjectWithTag("BulletSource");
		shooting = bulletSource.GetComponent<Shooting> ();

		colorSwitcher = GameObject.FindGameObjectWithTag("ColorController");
		colorController = colorSwitcher.GetComponent<ColorControllerUI> ();

		rectCorners = new Vector3[4];
		shootingImg.GetComponent<RectTransform> ().GetWorldCorners (rectCorners);
	}

	void Update () {
		Touch[] touches = Input.touches;

		if(GameManager.inPause || GameManager.inHelpMenu) {
			return;
		}

		for (int i = 0; i < touches.Length; i++) {
			Vector2 touchPos = touches[i].position;

			if(InShootBtnArea(touchPos)) {
				if(touches[i].phase == TouchPhase.Began) {
					shooting.Shoot();
					shootingImg.sprite = colorController.
						shootButtonPressedSprites[ColorControllerUI.curColorIndex];
					GetComponent<AudioSource>().Play();
				} else if (touches[i].phase == TouchPhase.Ended) {
					shootingImg.sprite = colorController.
						shootButtonSprites[ColorControllerUI.curColorIndex];
				}
			}
		}
	}

	/**
	 * True if touch was made in specific area
	 * */
	bool InShootBtnArea(Vector2 touchPos) {
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
}
