using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

	public Text gameOverText;
	private ScoreController scoreController;

	// Use this for initialization
	void Start () {
		scoreController = GameObject.Find ("ScoreTracker").GetComponent<ScoreController>();
		int playerOneScore = scoreController.playerOneScore;
		int playerTwoScore = scoreController.playerTwoScore;
		int winner = 1;
		if (playerTwoScore > playerOneScore) {
			winner = 2;
		}
		gameOverText.text = "Game Over! Player " + winner + " Won! Press A to Restart";
	}
	
	// Update is called once per frame
	void Update () {
		float playerOneA = Input.GetAxis ("j1Jump");
		float playerTwoA = Input.GetAxis ("j2Jump");
		if (playerOneA > 0 || playerTwoA > 0) {
			Destroy (scoreController.gameObject);
			SceneManager.LoadScene("Level_01");
		}
	}
}
