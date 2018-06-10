using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowHead : MonoBehaviour {

    public int speed = 500;

    private PlayerManager playerManager;
	private bool isThrowing;
	private GameObject body;
	private BodyController bodyController;
	private InputController inputController;
	private int playerNum;
	private string fireAxis;
	private PowerSliderBehaviour powerSlider;

	void Start () {
		body = this.gameObject;
		bodyController = body.GetComponent<BodyController> ();
		isThrowing = false;

        inputController = GameObject.FindWithTag ("GameController").GetComponent<InputController>();

        playerManager = this.transform.parent.gameObject.GetComponent<PlayerManager>();

        playerNum = playerManager.playerNumber;
		fireAxis = inputController.GetThrowInput (playerNum);
		powerSlider = GameObject.Find ("Player" + playerNum + "Slider").GetComponent<PowerSliderBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
		ThrowRigidBody ();
	}

	void ThrowRigidBody() {
        float joystickThrow = Input.GetAxis (fireAxis);
        if (playerManager.playerIsWhole && !isThrowing && joystickThrow < 0 ) {
            Debug.Log("ThrowRigidBody is firing");
            powerSlider.Activate ();
            isThrowing = true;
		}

		double tooMuchPower = powerSlider.GetPower ();
        if ((isThrowing && joystickThrow == 0) || tooMuchPower >= 1) {
            playerManager.playerIsWhole = false;
			double powerModifier = this.GetPowerModifierAndReset();
			GameObject head = bodyController.GetCurrentHead ();
			HeadController headController = head.GetComponent<HeadController> ();
            headController.SetLastThrownByPlayerNumber (playerNum);

            head.transform.parent = this.transform.parent;
            int adjustedSpeed = (int)(speed * powerModifier);
            bodyController.SetCurrentHead(null);
            headController.EnableHeadRigidbody();
            head.GetComponent<Rigidbody>().AddForce(-head.transform.forward * adjustedSpeed);
			isThrowing = false;
		}
	}

    void DetachHead(GameObject _head)
    {
        
    }

	double GetPowerModifierAndReset() {
		powerSlider.Release ();
		double powerModifier = powerSlider.GetPower ();
		powerSlider.Reset ();
		return powerModifier;
	}
}