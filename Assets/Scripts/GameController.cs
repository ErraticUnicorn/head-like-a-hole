using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {

	public int playerOneScore;
	public int playerTwoScore;
	public Text playerOneScoreText;
	public Text playerTwoScoreText;
	public Text gameOverText;
	public int numberOfPointsUntilGameOver;

	private InputController inputController;
	private ScoreController scoreController;
	private string startAxis1;
	private string startAxis2;

	// Use this for initialization
	void Start () {
		inputController = GameObject.FindWithTag ("GameController").GetComponent<InputController>();
		scoreController = GameObject.Find ("ScoreManager").GetComponent<ScoreController>();
		playerOneScore = scoreController.playerOneScore;
		playerOneScoreText.text = "Player 1: " + playerOneScore;
		playerTwoScore = scoreController.playerTwoScore;
		playerTwoScoreText.text = "Player 2: " + playerTwoScore;
	}

	void CheckForGameOver() {
		if (playerOneScore >= numberOfPointsUntilGameOver || playerTwoScore >= numberOfPointsUntilGameOver) {
			SceneManager.LoadScene ("Game_Over");
		}
	}

	public void AddScore (int scoreValue, int playerNum) {
		switch (playerNum) {
		case 1:
			playerOneScore += scoreValue;
			scoreController.playerOneScore = playerOneScore;
			playerOneScoreText.text = "Player 1: " + playerOneScore;
			CheckForGameOver ();
			break;
		case 2:
			playerTwoScore += scoreValue;
			scoreController.playerTwoScore = playerTwoScore;
			playerTwoScoreText.text = "Player 2: " + playerTwoScore;
			CheckForGameOver ();
			break;
		}
	}
}
