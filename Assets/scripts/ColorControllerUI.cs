using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorControllerUI : MonoBehaviour {

	public Image frameImage;
	public GameObject[] bulletObj;
	public Sprite[] bulletSprites;
	public Sprite[] frameSprites;
	public Sprite[] framePressedSprites;
	public Sprite[] shootButtonSprites;
	public Sprite[] shootButtonPressedSprites;
	public Sprite[] tubeSprites;
	public Sprite[] playerSprites;
	public Color[] textColors;

	public static int curColorIndex = 0;
	
	Vector3[] rectCorners;

	SpriteRenderer playerRenderer;
	SpriteRenderer tubeRenderer;

	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		GameObject tube = GameObject.FindGameObjectWithTag ("Tube");
		
		playerRenderer = player.GetComponent<SpriteRenderer> ();
		tubeRenderer = tube.GetComponent<SpriteRenderer> ();
		
		rectCorners = new Vector3[4];
		frameImage.GetComponent<RectTransform> ().GetWorldCorners (rectCorners);

		GetComponent<ColorControllerUI> ().enabled = true;

		curColorIndex = 0;
	}
	
	void Update () {
		Touch[] touches = Input.touches;
		
		for (int i = 0; i < touches.Length; i++) {
			Vector2 touchPos = touches[i].position;
			
			if(InShootBtnArea(touchPos)) {
				if (touches[i].phase == TouchPhase.Began) {
					SetActualColorPressed();
				} else if (touches[i].phase == TouchPhase.Ended) {
					SetActualColorReleased ();
				}
			}
		}

		if (GameManager.isGameOver) {
			GetComponent<ColorControllerUI>().enabled = false;
		}
	}

	void SetActualColorPressed() {
		frameImage.sprite = framePressedSprites[curColorIndex];
	}

	void SetActualColorReleased () {
		if (curColorIndex + 1 > 3) {
			curColorIndex = 0;
		} else {
			curColorIndex += 1;
		}
		
		playerRenderer.sprite = playerSprites[curColorIndex];
		tubeRenderer.sprite = tubeSprites[curColorIndex];
		frameImage.GetComponent<Image> ().sprite = frameSprites [curColorIndex];
		GetComponent<Text> ().color = textColors [curColorIndex];
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
