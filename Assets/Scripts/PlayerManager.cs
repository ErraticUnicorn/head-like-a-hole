using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    [HideInInspector] public bool playerIsWhole;
    [HideInInspector] public int playerNumber;

	// Use this for initialization
	void Start () {
        playerIsWhole = true;
        // Set playerNumber from tag
        int.TryParse(this.transform.tag.Substring(this.transform.tag.Length - 1), out playerNumber);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
