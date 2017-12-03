using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {
	public int playerOneScore;
	public int playerTwoScore;
	// Use this for initialization
	void Awake () {
		playerOneScore = 0;
		playerTwoScore = 0;
		DontDestroyOnLoad (this);
	}
}
