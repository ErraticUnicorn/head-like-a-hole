using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowHead : MonoBehaviour {

	public int speed;

	private GameObject head;
	private HeadController headController;
	// Use this for initialization
	void Start () {
		head = GameObject.Find ("Head");
		headController = head.GetComponent<HeadController> ();
	}
	
	// Update is called once per frame
	void Update () {
		ThrowRigidBody ();
	}

	void ThrowRigidBody() {
		float joystickThrow = Input.GetAxis ("JoyPad Fire");
		if (head.tag == "HeadIsAttached" && (Input.GetButtonDown ("Fire1") || joystickThrow < 0) ) {
			headController.enableHeadInteraction ();
			head.transform.parent = this.transform.parent;
			head.GetComponent<Rigidbody> ().AddForce (-head.transform.forward * speed);
			head.tag = "HeadIsDetached";
		}
	}
}