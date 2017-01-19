using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkColor : NetworkBehaviour {
    [SyncVar]
    private int colorIndex = 0;
    Color[] colorList = {
        Color.red,
        Color.blue,
        Color.yellow
    };
	
	// Update is called once per frame
    [ClientCallback]
	void Update () {
        if (isLocalPlayer && Input.GetKeyDown(KeyCode.Space))
        {
            CmdChangeColor();
        }

        var renderer = this.GetComponent<Renderer>();
        renderer.material.color = colorList[colorIndex % colorList.Length];
	}

    [Command]
    void CmdChangeColor()
    {
        colorIndex++;
    }
}
