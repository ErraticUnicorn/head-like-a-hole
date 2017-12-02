using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {
	
	public float jumpSpeed = 8.0f;

	private Vector3 moveDirection = Vector3.zero;
	private bool grounded = true;
	private InputController inputController;
	private int playerNum;
	private string jumpAxis;
	// Use this for initialization
	void Start () {
		inputController = GameObject.FindWithTag ("GameController").GetComponent<InputController>();
		string parentTag = this.transform.parent.tag;
		string lastChar = parentTag.Substring (parentTag.Length - 1);
		int.TryParse (lastChar, out playerNum);
		jumpAxis = inputController.GetThrowInput (playerNum);
	}
	
	void FixedUpdate() 
	{
		Jumping();
	}

	void Jumping() {
		if (grounded)
		{
			float joystickThrow = Input.GetAxis (jumpAxis);
			if (Input.GetButtonDown ("Jump") || joystickThrow < 0) {
				moveDirection.y = jumpSpeed;
				grounded = false;
			}
		}

		transform.Translate(0f, moveDirection.y * Time.deltaTime, 0f);
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Scenery")) {
			grounded = true;
			moveDirection.y = 0;
		}
	}

	public bool isGrounded () {
		return grounded;
	}
}
