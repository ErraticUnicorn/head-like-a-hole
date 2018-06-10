using UnityEngine;
using System.Collections;

public class BodyController : MonoBehaviour
{

	public float movementSpeed = 2.5f;
	public float rotationSpeed = 100f;
	public bool isWalking = false;

  private PlayerManager playerManager;
	private int playerNum;
	private InputController inputController;
	private string moveHorizontalAxis;
	private string moveVerticalAxis;
	private GameObject currentHead;
	private GameObject actualHead;

    // private Rigidbody rb;

    void Start() {
        playerManager = this.transform.parent.gameObject.GetComponent<PlayerManager>();
		inputController = GameObject.FindWithTag("GameController").GetComponent<InputController>();

        playerNum = playerManager.playerNumber;
		moveHorizontalAxis = inputController.GetBodyHorizontalInputString(playerNum);
		moveVerticalAxis = inputController.GetBodyVerticalInputString(playerNum);
		actualHead = this.transform.parent.Find("PlayerHead").gameObject;
		currentHead = null;
        playerManager.playerIsWhole = false;
    }

    void FixedUpdate() {
		float moveVertical = Input.GetAxis(moveVerticalAxis);
		float moveHorizontal = Input.GetAxis(moveHorizontalAxis);

		if (moveVertical != 0) {
			this.isWalking = true;
		}
		if (moveVertical == 0) {
			this.isWalking = false;
		}
		this.GetComponent<Animator> ().SetBool ("isWalking", this.isWalking);


		transform.Translate(0f, 0f, movementSpeed * moveVertical * Time.deltaTime);
		transform.Rotate(0f, rotationSpeed * moveHorizontal * Time.deltaTime, 0f);
    }

	public GameObject GetCurrentHead() {
        Debug.Log("GetCurrentHead is firing " + currentHead);
		return currentHead;
	}

	public GameObject GetActualHead() {
		return actualHead;
	}

	public void SetCurrentHead(GameObject _head) {
        Debug.Log("SetCurrentHead is firing " + _head);
		currentHead = _head;
	}
}
