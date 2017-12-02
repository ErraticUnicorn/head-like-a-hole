using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHead : MonoBehaviour {

	private GameObject body;
	private GameObject head;
	private HeadController headController;
	private Jump jumpScript;
	// Use this for initialization
	void Start () {
		body = this.gameObject;
		head = GameObject.Find ("Head");
		headController = head.GetComponent<HeadController> ();
		jumpScript = this.GetComponent<Jump> ();
	}

	void OnCollisionEnter(Collision collision) {
		bool isGrounded = jumpScript.isGrounded();
		if (collision.gameObject.tag == "HeadIsDetached" && isGrounded) {
			collision.gameObject.tag = "HeadIsAttached";
			collision.rigidbody.velocity = Vector3.zero;
			collision.rigidbody.angularVelocity = Vector3.zero;
			Transform bodyTransform = body.transform;
			Transform headTransform = head.transform;
			headTransform.parent = bodyTransform;
			headTransform.position = new Vector3 (bodyTransform.position.x, bodyTransform.position.y + 1.75f, bodyTransform.position.z);
			headTransform.rotation = Quaternion.Euler (bodyTransform.forward);
			headController.disableHeadInteraction ();
		}
	}
}
