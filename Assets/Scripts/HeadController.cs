using UnityEngine;
using System.Collections;

public class HeadController : MonoBehaviour {
    public float speed;
    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;

    [HideInInspector] public bool isDisabled;

    private PlayerManager playerManager;
    private Rigidbody myRigidbody;
    private InputController inputController;
    private int playerNum;
    private string moveHorizontalAxis;
    private string moveVerticalAxis;
    private int lastThrownByPlayerNumber;
    private float rotY = 0.0f;
    private float rotX = 0.0f;

    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;

        playerManager = this.transform.parent.gameObject.GetComponent<PlayerManager>();
        myRigidbody = GetComponent<Rigidbody>();

        inputController = GameObject.FindWithTag("GameController").GetComponent<InputController>();
        playerNum = playerManager.playerNumber;
        moveHorizontalAxis = inputController.GetHeadHorizontalInputString(playerNum);
        moveVerticalAxis = inputController.GetHeadVerticalInputString(playerNum);
        lastThrownByPlayerNumber = 0;
    }

    void Update()
    {
        float mouseX = Input.GetAxis(moveHorizontalAxis);
        float mouseY = -Input.GetAxis(moveVerticalAxis);

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
    }

    void FixedUpdate()
    {
		//float moveHorizontal = Input.GetAxis(moveHorizontalAxis);
		//float moveVertical = Input.GetAxis(moveVerticalAxis);

        //Vector3 eulerAngleVelocity = new Vector3(moveVertical, moveHorizontal, 0);
        //Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * speed);

        //myRigidbody.MoveRotation(myRigidbody.rotation * deltaRotation);
    }

    public void EnableHeadRigidbody()
    {
        Debug.Log("EnableHeadRigidbody is firing");
        isDisabled = false;
        myRigidbody = this.transform.parent.gameObject.AddComponent<Rigidbody>();
	}

    public void DisableHeadRigidbody()
    {
        Debug.Log("DisableHeadRigidbody is firing");
        isDisabled = true;
        Destroy(myRigidbody);
	}

	public void SetLastThrownByPlayerNumber(int playerNumber)
    {
		lastThrownByPlayerNumber = playerNumber;
	}

	public int GetLastThrownByPlayerNumber()
    {
		return lastThrownByPlayerNumber;
	}
}
