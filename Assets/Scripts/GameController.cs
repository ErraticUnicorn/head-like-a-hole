using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public int score;
	public Text scoreText;

	// Use this for initialization
	void Start () {
		score = 0;
		UpdateScore ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddScore (int scoreValue) {
		score += scoreValue;
		UpdateScore ();
	}

	public void UpdateScore () {
		scoreText.text = "SCORE: " + score;
	}
}
