using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHead : MonoBehaviour {

	private GameObject body;
	private BodyController bodyController;
	private Jump jumpScript;
	private Transform parent;
	// Use this for initialization
	void Start () {
		body = this.gameObject;
		bodyController = body.GetComponent<BodyController> ();
		parent = this.transform.parent;
		jumpScript = this.GetComponent<Jump> ();
	}

	void OnCollisionEnter(Collision collision) {
		bool isOnGround = jumpScript.GetIsOnGround();
		if (collision.gameObject.tag == "HeadIsDetached" && isOnGround && bodyController.isDecapitated) {
			collision.gameObject.tag = "HeadIsAttached";
			collision.rigidbody.velocity = Vector3.zero;
			collision.rigidbody.angularVelocity = Vector3.zero;
			Transform bodyTransform = body.transform;
			Transform headTransform = collision.gameObject.transform;
			HeadController headController = collision.gameObject.GetComponent<HeadController> ();
			headTransform.parent = bodyTransform;
			headTransform.position = new Vector3 (bodyTransform.position.x, bodyTransform.position.y + 1.75f, bodyTransform.position.z);
			headTransform.rotation = Quaternion.Euler (bodyTransform.forward);
			headController.disableHeadInteraction ();
			bodyController.SetCurrentHead (collision.gameObject);
			bodyController.isDecapitated = false;
		}
	}
}
