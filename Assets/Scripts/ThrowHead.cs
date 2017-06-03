using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowHead : MonoBehaviour {

	public int speed;

	private GameObject head;
	// Use this for initialization
	void Start () {
		head = GameObject.Find ("Head");
	}
	
	// Update is called once per frame
	void Update () {
		ThrowRigidBody ();
	}

	void ThrowRigidBody() {
		if (head.tag == "HeadIsAttached" && Input.GetButtonDown ("Fire1") ) {
			head.tag = "HeadIsDetached";
			head.transform.parent = this.transform.parent;
			head.GetComponent<Rigidbody> ().AddForce (head.transform.forward * speed);
		}
	}
}