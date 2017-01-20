using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class UsagisanMessageType
{
    // MsgTypeが拡張できるならそっちでやる。
    public static readonly short ChangeColor = MsgType.Highest + 1;
}

public class NetworkColor : NetworkBehaviour {
    [SyncVar]
    private int colorIndex = 0;
    Color[] colorList = {
        Color.red,
        Color.blue,
        Color.yellow
    };

    class ColorMessage : MessageBase
    {
        public Color color;
    }


    void Start()
    {
        
        NetworkManager.singleton.client.RegisterHandler(UsagisanMessageType.ChangeColor, (netMsg) =>
        {
            ColorMessage colorMessage = netMsg.ReadMessage<ColorMessage>();
            var renderer = this.GetComponent<Renderer>();
            renderer.material.color = colorMessage.color;
        });
    }
	
	// Update is called once per frame//[ClientCallback]
	void Update () {
        if (isLocalPlayer && Input.GetKeyDown(KeyCode.Space))
        {
            //CmdChangeColor();
            ChangeColorMessage();
        }
	}

    [Command]
    void CmdChangeColor()
    {
        colorIndex++;
    }

    void ChangeColorMessage()
    {
        colorIndex++;
        ColorMessage message = new ColorMessage();
        message.color = colorList[colorIndex % 3];

        NetworkServer.SendToAll(UsagisanMessageType.ChangeColor, message);
    }
}
