using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour {

	public GameObject body;
	BodyController bodyController;
	AudioManager audioManager;
	private string footOrientationString = "Right";
	private string playerString = "P1";

	void Start () {
		bodyController = body.GetComponent<BodyController> ();
		audioManager = FindObjectOfType<AudioManager> ();
		if(gameObject.name.Contains("L")) {
			footOrientationString = "Left";
		}

		GameObject playerTwo = GameObject.Find ("PlayerTwo");
		if(gameObject.transform.IsChildOf(playerTwo.transform)) {
			playerString = "P2";
		}
	}


	void OnTriggerStay(Collider other) {
		if (bodyController.isWalking) {
			audioManager.Play (playerString + " " + footOrientationString + " Footstep");
		}
	}
}
