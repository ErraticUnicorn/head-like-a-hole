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

    void Start()
    {
        rb = GetComponent<Rigidbody>();

		inputController = GameObject.FindWithTag ("GameController").GetComponent<InputController>();
		string parentTag = this.transform.parent.tag;
		string lastChar = parentTag.Substring (parentTag.Length - 1);
		int.TryParse (lastChar, out playerNum);
		moveHorizontalAxis = inputController.GetHeadHorizontalInputString (playerNum);
		moveVerticalAxis = inputController.GetHeadVerticalInputString (playerNum);
    }

    void FixedUpdate()
    {
		float moveHorizontal = Input.GetAxis(moveHorizontalAxis);
		float moveVertical = Input.GetAxis(moveVerticalAxis);

        Vector3 eulerAngleVelocity = new Vector3(moveVertical, moveHorizontal, 0);
        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * speed);

        rb.MoveRotation(rb.rotation * deltaRotation);
    }

	public void enableHeadInteraction () {
		Physics.IgnoreLayerCollision(8, 9, false);
		this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
	}

	public void disableHeadInteraction () {
		Physics.IgnoreLayerCollision(8, 9, true);
		this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
	}
}
