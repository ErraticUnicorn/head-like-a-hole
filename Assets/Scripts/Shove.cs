using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shove : MonoBehaviour {

	public float shoveForce = 100f;

    private PlayerManager playerManager;
    private PlayerManager shovedPlayerManager;
    private BodyController shovedBodyController;
    private HeadController shovedHeadController;
    private int playerNum;
	private string shoveAxis;
    private InputController inputController;

    // Use this for initialization
    void Start ()
    {
        playerManager = this.transform.parent.transform.parent.gameObject.GetComponent<PlayerManager>();

        playerNum = playerManager.playerNumber;
        inputController = GameObject.FindWithTag("GameController").GetComponent<InputController>();
        shoveAxis = inputController.GetShoveInput(playerNum);
    }
    
    // Update is called once per frame
    void Update ()
    {
        float shovePressedState = Input.GetAxis(shoveAxis);
        bool shoveIsPressed = !isEqual(shovePressedState, 0f);
        if (shoveIsPressed)
            PresentShover();
        else
            RetractShover();
    }

    bool isEqual(float a, float b)
    {
        if (a >= b - Mathf.Epsilon && a <= b + Mathf.Epsilon)
            return true;
        else
            return false;
    }

    void PresentShover()
    {
        Vector3 startingLocalPosition = this.transform.localPosition;
        Vector3 endingLocalPosition = new Vector3(0f, 1f, 1f);
        this.transform.localPosition = Vector3.Lerp(startingLocalPosition, endingLocalPosition, 0.5f);
        this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    void RetractShover()
    {
        Vector3 startingLocalPosition = this.transform.localPosition;
        Vector3 endingLocalPosition = new Vector3(0f, 1f, 0f);
        this.transform.localPosition = Vector3.Lerp(startingLocalPosition, endingLocalPosition, 0.5f);
        this.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
    }

    void ShoveRigidbody(Collider _collider)
    {
        GameObject myBody = this.transform.parent.gameObject;
        GameObject shovedGameObject = _collider.gameObject;
        Debug.Log("ShoveRigidbody is firing " + shovedGameObject);

        //current player position - shoved player position?
        Vector3 shovedDirection = (shovedGameObject.transform.position - myBody.transform.position).normalized;

        bool colliderIsRigidbody = CheckIsPushingRigidbody(_collider);
        bool colliderIsBody = CheckIsPushingBody(_collider);
        if (colliderIsRigidbody)
        {
            Debug.Log("Shoving a rigidbody");
            if (colliderIsBody)
            {
                Debug.Log("Who is a body");
                shovedPlayerManager = GetPlayerManager(_collider.transform.parent.gameObject);
                shovedBodyController = GetBodyController(_collider.gameObject);
                shovedHeadController = GetHeadController(shovedBodyController.GetCurrentHead());
                Debug.Log(shovedBodyController.GetCurrentHead());
                if (shovedPlayerManager.playerIsWhole)
                {
                    Debug.Log("Who is whole");
                    shovedBodyController.SetCurrentHead(null);
                    shovedPlayerManager.playerIsWhole = false;
                    shovedHeadController.DisableHeadRigidbody();
                }
                else
                {
                    Debug.Log("Who is headless");
                }
            }
            _collider.GetComponent<Rigidbody>().AddForce(shovedDirection * shoveForce);
        }
	}

    BodyController GetBodyController(GameObject _gameObject)
    {
        return _gameObject.GetComponent<BodyController>();
    }

    HeadController GetHeadController(GameObject _gameObject)
    {
        return _gameObject.GetComponent<HeadController>();
    }

    PlayerManager GetPlayerManager(GameObject _gameObject)
    {
        return _gameObject.GetComponent<PlayerManager>();
    }

    bool CheckIsPushingRigidbody(Collider _collider)
    {
        return _collider.GetComponent<Rigidbody>();
    }

    bool CheckIsPushingBody(Collider _collider)
    {
        return _collider.transform.tag == "Body";
    }

    void OnTriggerEnter(Collider other)
    {
        ShoveRigidbody(other);
	}
}
