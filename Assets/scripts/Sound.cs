using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Sound : MonoBehaviour {

	public Sprite soundOnSprite;
	public Sprite soundOffSprite;
	Image backImage;
	Image iconImage;

	void Start() {
		backImage = GetComponent<Image> ();
		iconImage = GetComponentInChildren<Image> ();
	}

	public void MuteSoundState(bool soundOn) {
		if (soundOn) {
			backImage.color = GetColor (1f);
			iconImage.color = GetColor (1f);
			AudioListener.volume = 1f;
		} else {
			backImage.color = GetColor (0.4f);
			iconImage.color = GetColor (0.4f);
			AudioListener.volume = 0;
		}

		GameManager.soundOn = soundOn;
	}

	Color GetColor(float alpha) {
		return new Color (1f, 1f, 1f, alpha);
	}
}
