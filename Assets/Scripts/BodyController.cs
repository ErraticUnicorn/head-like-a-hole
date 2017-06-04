using UnityEngine;
using System.Collections;

public class BodyController : MonoBehaviour
{

	public float movementSpeed;
	public float rotationSpeed;

    // private Rigidbody rb;

    void Start() {
		
    }

    void FixedUpdate() {
		string[] names = Input.GetJoystickNames();
		float moveVertical = Input.GetAxis("Vertical2");
		float moveHorizontal = Input.GetAxis("Horizontal2");
		if (names.Length > 0) {
			moveHorizontal = Input.GetAxis ("RightJoyStick1 X");
			moveVertical = Input.GetAxis ("RightJoyStick1 Y");
		}

		transform.Translate(0f, movementSpeed * moveHorizontal * Time.deltaTime, 0f);
		transform.Rotate(0f, 0f, rotationSpeed * moveVertical * Time.deltaTime);
    }
}
