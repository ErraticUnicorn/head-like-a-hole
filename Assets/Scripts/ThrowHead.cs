using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowHead : MonoBehaviour {

	public int speed = 500;

	private bool isThrowing;
	private GameObject body;
	private BodyController bodyController;
	private InputController inputController;
	private int playerNum;
	private string fireAxis;
	private PowerSliderBehaviour powerSlider;
	// Use this for initialization
	void Start () {
		body = this.gameObject;
		bodyController = body.GetComponent<BodyController> ();
		isThrowing = false;

		inputController = GameObject.FindWithTag ("GameController").GetComponent<InputController>();
		string parentTag = this.transform.parent.tag;
		string playerNumberChar = parentTag.Substring (parentTag.Length - 1);
		int.TryParse (playerNumberChar, out playerNum);
		fireAxis = inputController.GetThrowInput (playerNum);
		powerSlider = GameObject.Find ("Player" + playerNum + "Slider").GetComponent<PowerSliderBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
		ThrowRigidBody ();
	}

	void ThrowRigidBody() {
		float joystickThrow = Input.GetAxis (fireAxis);
		if (!bodyController.isDecapitated && !isThrowing && joystickThrow < 0 ) {
			powerSlider.Activate ();
			isThrowing = true;
		}

		double tooMuchPower = powerSlider.GetPower ();
		if ((isThrowing && joystickThrow == 0) || tooMuchPower >= 1) {
			double powerModifier = this.GetPowerModifierAndReset ();
			GameObject head = bodyController.GetCurrentHead ();
			HeadController headController = head.GetComponent<HeadController> ();
			headController.EnableHeadInteraction ();
			headController.SetLastThrownByPlayerNumber (playerNum);
			head.transform.parent = this.transform.parent;
			int adjustedSpeed = (int)(speed * powerModifier);
			head.GetComponent<Rigidbody> ().AddForce (-head.transform.forward * adjustedSpeed);
			head.tag = "isBodyless";
			bodyController.SetCurrentHead(null);
			bodyController.isDecapitated = true;
			isThrowing = false;
		}
	}

	double GetPowerModifierAndReset() {
		powerSlider.Release ();
		double powerModifier = powerSlider.GetPower ();
		powerSlider.Reset ();
		return powerModifier;
	}
}