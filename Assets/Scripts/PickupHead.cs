using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHead : MonoBehaviour {
    
    private PlayerManager playerManager;
    private GameObject body;
	private BodyController bodyController;

	void Start () {
        playerManager = this.transform.parent.gameObject.GetComponent<PlayerManager>();

        body = this.gameObject;
		bodyController = body.GetComponent<BodyController> ();
	}


    // 
	void OnCollisionEnter(Collision collision) {
        Debug.Log("Colliding with something");
        bool headIsPickupable = CheckIsHeadPickupable(collision);
        bool bodyIsReady = CheckIsBodyReady(body);
        if(bodyIsReady && headIsPickupable) {
            Debug.Log("That something is a head");
            playerManager.playerIsWhole = true;
            PositionHead(collision.gameObject);
            AttachHead(collision.gameObject);
            bodyController.SetCurrentHead(collision.gameObject);
		}
	}

    bool CheckIsBodyReady(GameObject _body)
    {
        Debug.Log("CheckIsBodyReady is firing");
        return (_body.GetComponent<Jump>().GetIsOnGround() && !_body.transform.parent.gameObject.GetComponent<PlayerManager>().playerIsWhole);
    }

    bool CheckIsHeadPickupable(Collision _collision)
    {
        HeadController collisionObjectHeadController = _collision.gameObject.GetComponent<HeadController>();
        if (collisionObjectHeadController)
        {
            return !collisionObjectHeadController.isDisabled;
        }
        else
        {
            return false;
        }
    }

    void AttachHead(GameObject _head)
    {
        Debug.Log("AttachHead is firing");
        _head.transform.parent = body.transform;
    }

    void PositionHead(GameObject _head)
    {
        Debug.Log("PositionHead is firing");
        HeadController headController = _head.GetComponent<HeadController>();
        headController.DisableHeadRigidbody();

        _head.transform.rotation = Quaternion.Euler(body.transform.forward);
        _head.transform.position = new Vector3(body.transform.position.x, body.transform.position.y + 1.75f, body.transform.position.z);
    }
}
