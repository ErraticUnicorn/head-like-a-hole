using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour {

	public int pointValue;

	private GameController gameController;

	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.name == "Head") {
			HeadController headController = collision.gameObject.GetComponent<HeadController> ();
			gameController.AddScore (pointValue, headController.GetLastThrownByPlayerNumber());
			this.gameObject.transform.position = new Vector3(Random.Range(-9, 9), 6f, Random.Range(-10, 10));
		}
	}
}
