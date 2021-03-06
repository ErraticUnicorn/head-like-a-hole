﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shove : MonoBehaviour {

	public float shoveForce = 500f;

	private int playerNum;
	private string shoveAxis;
	private InputController inputController;

	private GameObject shovedPlayer;


	// Use this for initialization
	void Start () {
		inputController = GameObject.FindWithTag ("GameController").GetComponent<InputController>();
		string parentTag = this.transform.parent.tag;
		string playerNumberChar = parentTag.Substring (parentTag.Length - 1);
		int.TryParse (playerNumberChar, out playerNum);
		shoveAxis = inputController.GetShoveInput (playerNum);
	}
	
	// Update is called once per frame
	void Update () {
		ShovePlayer ();
	}

	void ShovePlayer() {
		float joystickShove = Input.GetAxis (shoveAxis);
		if (joystickShove > 0 && shovedPlayer != null) {
			Rigidbody opponentRigidBody = shovedPlayer.transform.GetComponent<Rigidbody> ();


			//current player position - shoved player position?
			Vector3 shovedDirection = (shovedPlayer.transform.position - this.gameObject.transform.position).normalized;
			opponentRigidBody.AddForce (shovedDirection*shoveForce);
			BodyController bodyController = shovedPlayer.GetComponent<BodyController> ();
			if (!bodyController.isDecapitated) {
				shovedPlayer.GetComponent<PickupHead> ().disableForSeconds(1);
				GameObject opponentHead = bodyController.GetCurrentHead ();
				HeadController opponentHeadController = opponentHead.GetComponent<HeadController> ();
				opponentHeadController.EnableHeadInteraction ();
				opponentHead.transform.parent = this.transform.parent;
				opponentHead.GetComponent<Rigidbody> ().AddForce (gameObject.transform.forward * 500);
				opponentHead.tag = "isBodyless";
				bodyController.SetCurrentHead(null);
				bodyController.isDecapitated = true;
			}
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "PlayerBody") {
			shovedPlayer = collision.gameObject;
		}
	}

	void OnCollisionExit(Collision collision) {
		if (collision.gameObject.name == "PlayerBody") {
			shovedPlayer = null;
		}
	}
}
