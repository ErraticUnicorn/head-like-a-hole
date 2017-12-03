using UnityEngine;
using System.Collections;

public class HeadController : MonoBehaviour
{

    public float speed;

    private Rigidbody rb;
	private InputController inputController;
	private int playerNum;
	private string moveHorizontalAxis;
	private string moveVerticalAxis;
	private int lastThrownByPlayerNumber;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

		inputController = GameObject.FindWithTag ("GameController").GetComponent<InputController>();
		string parentTag = this.transform.parent.tag;
		string playerNumberChar = parentTag.Substring (parentTag.Length - 1);
		int.TryParse (playerNumberChar, out playerNum);
		moveHorizontalAxis = inputController.GetHeadHorizontalInputString (playerNum);
		moveVerticalAxis = inputController.GetHeadVerticalInputString (playerNum);
		lastThrownByPlayerNumber = 0;
    }

    void FixedUpdate()
    {
		float moveHorizontal = Input.GetAxis(moveHorizontalAxis);
		float moveVertical = Input.GetAxis(moveVerticalAxis);

        Vector3 eulerAngleVelocity = new Vector3(moveVertical, moveHorizontal, 0);
        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * speed);

        rb.MoveRotation(rb.rotation * deltaRotation);
    }

	public void EnableHeadInteraction () {
		if(playerNum == 1){ 
			Physics.IgnoreLayerCollision (8, 9, false);
		} else {
			Physics.IgnoreLayerCollision (8, 10, false);
		}
		this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
	}

	public void DisableHeadInteraction () {
		if(playerNum == 1){ 
			Physics.IgnoreLayerCollision(8, 9, true);
		} else {
			Physics.IgnoreLayerCollision(8, 10, true);
		}
		this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
	}

	public void SetLastThrownByPlayerNumber(int playerNumber) {
		lastThrownByPlayerNumber = playerNumber;
	}

	public int GetLastThrownByPlayerNumber() {
		return lastThrownByPlayerNumber;
	}
}
