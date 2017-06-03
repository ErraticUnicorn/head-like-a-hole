using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHead : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "HeadIsDetached") {
			collision.gameObject.tag = "HeadIsAttached";
			collision.rigidbody.velocity = Vector3.zero;
			collision.rigidbody.angularVelocity = Vector3.zero;
			Transform bodyTransform = this.gameObject.transform;
			Transform headTransform = collision.gameObject.transform;
			headTransform.Translate (bodyTransform.position.x, bodyTransform.position.y + 0.75f, bodyTransform.position.z);
			headTransform.parent = bodyTransform;
		}
	}
}
