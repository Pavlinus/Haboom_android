using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatisticsMenuUI : MonoBehaviour {

	public Text redText;
	public Text greenText;
	public Text blueText;
	public Text orangeText;
	public Text scoreText;

	void Start () {
		redText.text = GameManager.redEnemies.ToString();
		greenText.text = GameManager.greenEnemies.ToString();
		blueText.text = GameManager.blueEnemies.ToString();
		orangeText.text = GameManager.orangeEnemies.ToString();
		scoreText.text = "SCORE " + GameManager.totalScore;
	}
}
