using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
	
	private bool controllersConnected;
	private string[] names;
	// Use this for initialization
	void Awake () {
		names = Input.GetJoystickNames();
		if (names.Length > 0) {
			controllersConnected = true;
		} else {
			controllersConnected = false;
		}
	}

	public string GetHeadHorizontalInputString(int playerNum) {
		if (controllersConnected) {
			return "RightJoyStick1 X";
		} else {
			return "Mouse X";
		}
	}

	public string GetHeadVerticalInputString(int playerNum) {
		if (controllersConnected) {
			return "RightJoyStick1 Y";
		} else {
			return "Mouse Y";
		}
	}

	public string GetBodyHorizontalInputString(int playerNum) {
		if (controllersConnected) {
			return "LeftJoyStick1 X";
		} else {
			return "Horizontal2";
		}
	}

	public string GetBodyVerticalInputString(int playerNum) {
		if (controllersConnected) {
			return "LeftJoyStick1 Y";
		} else {
			return "Vertical2";
		}
	}

	public string GetJumpInput(int playerNum) {
		return "Jump";
	}

	public string GetThrowInput(int playerNum) {
		return "JoyPad Fire";
	}
}
