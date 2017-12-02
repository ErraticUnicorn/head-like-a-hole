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
			return "j"+playerNum+"RightJoyStick1 X";
		} else {
			return "Mouse X";
		}
	}

	public string GetHeadVerticalInputString(int playerNum) {
		if (controllersConnected) {
			return "j"+playerNum+"RightJoyStick1 Y";
		} else {
			return "Mouse Y";
		}
	}

	public string GetBodyHorizontalInputString(int playerNum) {
		if (controllersConnected) {
			return "j"+playerNum+"LeftJoyStick1 X";
		} else {
			return "Horizontal2";
		}
	}

	public string GetBodyVerticalInputString(int playerNum) {
		if (controllersConnected) {
			return "j"+playerNum+"LeftJoyStick1 Y";
		} else {
			return "Vertical2";
		}
	}

	public string GetJumpInput(int playerNum) {
		return "j"+playerNum+"Jump";
	}

	public string GetThrowInput(int playerNum) {
		return "j"+playerNum+"JoyPad Fire";
	}
}
