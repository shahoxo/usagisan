using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MoveController : NetworkBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (this.isLocalPlayer && Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * Time.deltaTime);
		
	}
}
