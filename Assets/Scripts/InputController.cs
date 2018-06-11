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
			return "j"+playerNum + "RightJoyStick1 X";
		} else {
			return "keyboardHeadHorizontal"+playerNum;
		}
	}

	public string GetHeadVerticalInputString(int playerNum) {
		if (controllersConnected) {
			return "j"+playerNum + "RightJoyStick1 Y";
		} else {
			return "keyboardHeadVertical"+playerNum;
		}
	}

	public string GetBodyHorizontalInputString(int playerNum) {
		if (controllersConnected) {
			return "j"+playerNum+"LeftJoyStick1 X";
		} else {
			return "Horizontal" + playerNum;
		}
	}

	public string GetBodyVerticalInputString(int playerNum) {
		if (controllersConnected) {
			return "j"+playerNum+"LeftJoyStick1 Y";
		} else {
			return "Vertical" + playerNum;
		}
	}

	public string GetJumpInput(int playerNum) {
		if (controllersConnected) {
			return "j"+playerNum+"Jump";
		} else {
			return "Jump" + playerNum;
		}
	}

	public string GetThrowInput(int playerNum) {
		if (controllersConnected) {
			return "j" + playerNum + "JoyPad Fire";
		} else {
			return "Fire" + playerNum;
		}
	}

	public string GetShoveInput(int playerNum) {
		if (controllersConnected) {
			return "j" + playerNum + "JoyPad Shove";
		} else {
			return "Push" + playerNum;
		}
	}
}
