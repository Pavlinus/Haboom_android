using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Sound : MonoBehaviour {

	public Sprite soundOn;
	public Sprite soundOff;
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
		} else {
			backImage.color = GetColor (0.4f);
			iconImage.color = GetColor (0.4f);
		}

		GameManager.soundOn = soundOn;
	}

	Color GetColor(float alpha) {
		return new Color (1f, 1f, 1f, alpha);
	}
}
