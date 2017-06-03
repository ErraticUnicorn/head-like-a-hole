using UnityEngine;
using System.Collections;

public class BodyController : MonoBehaviour
{

    public float speed;

    // private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // float moveHorizontal = Input.GetAxis("Horizontal2");
        // float moveVertical = Input.GetAxis("Vertical2");
        //
        // Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //
        // rb.AddForce(movement * speed);
		transform.Translate(speed*Input.GetAxis("Horizontal2")*Time.deltaTime, 0f, speed*Input.GetAxis("Vertical2")*Time.deltaTime);
    }
}
