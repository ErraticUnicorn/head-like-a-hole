using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour {

	public int pointValue = 1;
	public float goalHeight = 2f;

	private GameController gameController;

	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent<GameController>();
		this.gameObject.transform.position = new Vector3(0f, goalHeight, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.name == "PlayerHead") {
			HeadController headController = collision.gameObject.GetComponent<HeadController> ();
			gameController.AddScore (pointValue, headController.GetLastThrownByPlayerNumber());
			this.gameObject.transform.position = new Vector3(Random.Range(-9, 9), goalHeight, Random.Range(-9, 9));
		}
	}
}
