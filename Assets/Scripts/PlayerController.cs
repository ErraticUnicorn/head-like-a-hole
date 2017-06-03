using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal1");
        float moveVertical = Input.GetAxis("Vertical1");

        Vector3 eulerAngleVelocity = new Vector3(-moveVertical, moveHorizontal, 0);
        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * speed);

        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
