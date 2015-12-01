using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	Animator animator;
	
	void Start () {
		animator = GetComponent<Animator> ();
	}

	public void SetParameter(string param, bool state = false) {
		switch(param) {
		case "splashIn":
			animator.SetTrigger ("splashIn");
			break;

		case "splashActive":
			animator.SetBool ("splashActive", state);
			break;

		case "splashOut":
			animator.SetTrigger ("splashOut");
			break;
		}
	}
}
