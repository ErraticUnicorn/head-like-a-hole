using UnityEngine;
using System.Collections;

public class BodyController : MonoBehaviour
{

	public float movementSpeed;
	public float rotationSpeed;

    // private Rigidbody rb;

    void Start()
    {
//        Rigidbody rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // float moveHorizontal = Input.GetAxis("Horizontal2");
        // float moveVertical = Input.GetAxis("Vertical2");
        //
        // Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //
        // rb.AddForce(movement * speed);
		transform.Translate(0f, -(movementSpeed * Input.GetAxis("Vertical2") * Time.deltaTime), 0f);
		transform.Rotate(0f, 0f, rotationSpeed * Input.GetAxis("Horizontal2") * Time.deltaTime);
		
    }
}
