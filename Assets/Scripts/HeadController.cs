using UnityEngine;
using System.Collections;

public class HeadController : MonoBehaviour
{

    public float speed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

		string[] names = Input.GetJoystickNames();
		float moveHorizontal = Input.GetAxis("Mouse X");
		float moveVertical = -Input.GetAxis("Mouse Y");

		if (names.Length > 0) {
			moveHorizontal = Input.GetAxis ("RightJoyStick1 X");
			moveVertical = Input.GetAxis ("RightJoyStick1 Y");
		}

        Vector3 eulerAngleVelocity = new Vector3(-moveVertical, moveHorizontal, 0);
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
