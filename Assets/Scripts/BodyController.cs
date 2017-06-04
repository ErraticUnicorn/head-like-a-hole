using UnityEngine;
using System.Collections;

public class BodyController : MonoBehaviour
{

	public float movementSpeed;
	public float rotationSpeed;

	private int playerNum;
	private InputController inputController;
	private string moveHorizontalAxis;
	private string moveVerticalAxis;

    // private Rigidbody rb;

    void Start() {
		inputController = GameObject.FindWithTag ("GameController").GetComponent<InputController>();
		string parentTag = this.transform.parent.tag;
		string lastChar = parentTag.Substring (parentTag.Length - 1);
		int.TryParse (lastChar, out playerNum);
		moveHorizontalAxis = inputController.GetBodyHorizontalInputString (playerNum);
		moveVerticalAxis = inputController.GetBodyVerticalInputString (playerNum);
		Debug.Log (moveVerticalAxis);
    }

    void FixedUpdate() {
		float moveVertical = Input.GetAxis(moveVerticalAxis);
		float moveHorizontal = Input.GetAxis(moveHorizontalAxis);

		transform.Translate(0f, movementSpeed * moveVertical * Time.deltaTime, 0f);
		transform.Rotate(0f, 0f, rotationSpeed * moveHorizontal * Time.deltaTime);
    }
}
