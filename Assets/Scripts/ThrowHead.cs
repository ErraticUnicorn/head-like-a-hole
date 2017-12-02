using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowHead : MonoBehaviour {

	public int speed;

	private GameObject body;
	private BodyController bodyController;
	private InputController inputController;
	private int playerNum;
	private string fireAxis;
	// Use this for initialization
	void Start () {
		body = this.gameObject;
		bodyController = body.GetComponent<BodyController> ();

		inputController = GameObject.FindWithTag ("GameController").GetComponent<InputController>();
		string parentTag = this.transform.parent.tag;
		string playerNumberChar = parentTag.Substring (parentTag.Length - 1);
		int.TryParse (playerNumberChar, out playerNum);
		fireAxis = inputController.GetThrowInput (playerNum);
	}
	
	// Update is called once per frame
	void Update () {
		ThrowRigidBody ();
	}

	void ThrowRigidBody() {
		float joystickThrow = Input.GetAxis (fireAxis);

		if (!bodyController.isDecapitated && (Input.GetButtonDown ("Fire1") || joystickThrow < 0) ) {
			GameObject head = bodyController.GetCurrentHead ();
			HeadController headController = head.GetComponent<HeadController> ();
			headController.enableHeadInteraction ();
			head.transform.parent = this.transform.parent;
			head.GetComponent<Rigidbody> ().AddForce (-head.transform.forward * speed);
			head.tag = "HeadIsDetached";
			bodyController.SetCurrentHead(null);
			bodyController.isDecapitated = true;
		}
	}
}