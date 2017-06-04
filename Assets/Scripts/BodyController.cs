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
		transform.Translate(0f, -(movementSpeed * Input.GetAxis("Vertical2") * Time.deltaTime), 0f);
		transform.Rotate(0f, 0f, rotationSpeed * Input.GetAxis("Horizontal2") * Time.deltaTime);
    }
}
