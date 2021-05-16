using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerHelper : NetworkBehaviour
{
    private GameHelper _helper;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _helper = GameObject.FindObjectOfType<GameHelper>();
        _helper.currentPlayer = this;
        
    }

    [Command]
    public void CmdSend(string message)
    {
        RpcSend(message);
    }

    [ClientRpc]
    public void RpcSend(string message)
    {
        _helper.text.text += System.Environment.NewLine + message;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
