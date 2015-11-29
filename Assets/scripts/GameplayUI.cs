using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameplayUI : MonoBehaviour {

	public Text totalScore;
	public Text redEnemyText;
	public Text greenEnemyText;
	public Text blueEnemyText;
	public Text orangeEnemyText;

	void Update () {
		totalScore.text = "Score " + GameManager.totalScore;
		redEnemyText.text = " " + GameManager.redEnemies.ToString();
		greenEnemyText.text = " " + GameManager.greenEnemies.ToString();
		blueEnemyText.text = " " + GameManager.blueEnemies.ToString();
		orangeEnemyText.text = " " + GameManager.orangeEnemies.ToString();
	}
}
