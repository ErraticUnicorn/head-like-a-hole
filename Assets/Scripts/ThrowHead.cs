using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowHead : MonoBehaviour {

	public int speed;

	private GameObject head;
	private HeadController headController;
	private InputController inputController;
	private int playerNum;
	private string fireAxis;
	// Use this for initialization
	void Start () {
		head = GameObject.Find ("Head");
		headController = head.GetComponent<HeadController> ();

		inputController = GameObject.FindWithTag ("GameController").GetComponent<InputController>();
		string parentTag = this.transform.parent.tag;
		string lastChar = parentTag.Substring (parentTag.Length - 1);
		int.TryParse (lastChar, out playerNum);
		fireAxis = inputController.GetThrowInput (playerNum);
	}
	
	// Update is called once per frame
	void Update () {
		ThrowRigidBody ();
	}

	void ThrowRigidBody() {
		float joystickThrow = Input.GetAxis (fireAxis);
		if (head.tag == "HeadIsAttached" && (Input.GetButtonDown ("Fire1") || joystickThrow < 0) ) {
			headController.enableHeadInteraction ();
			head.transform.parent = this.transform.parent;
			head.GetComponent<Rigidbody> ().AddForce (-head.transform.forward * speed);
			head.tag = "HeadIsDetached";
		}
	}
}