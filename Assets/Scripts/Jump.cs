using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {
	
	public float jumpSpeed = 8.0f;

	private Vector3 moveDirection = Vector3.zero;
	private bool _isOnGround = true;
	private InputController inputController;
	private int playerNum;
	private string jumpAxis;
	// Use this for initialization
	void Start () {
		inputController = GameObject.FindWithTag ("GameController").GetComponent<InputController>();
		string parentTag = this.transform.parent.tag;
		string lastChar = parentTag.Substring (parentTag.Length - 1);
		int.TryParse (lastChar, out playerNum);
		jumpAxis = inputController.GetJumpInput (playerNum);
	}
	
	void FixedUpdate() 
	{
		CheckJump();
	}

	void CheckJump() {
		if (_isOnGround)
		{
			float jumpDirection = Input.GetAxis (jumpAxis);
			if (Input.GetButtonDown ("Jump") || jumpDirection < 0) {
				moveDirection.y = jumpSpeed;
				_isOnGround = false;
			}
		}

		transform.Translate(0f, moveDirection.y * Time.deltaTime, 0f);
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Scenery")) {
			_isOnGround = true;
			moveDirection.y = 0;
		}
	}

	public bool GetIsOnGround () {
		return _isOnGround;
	}
}
