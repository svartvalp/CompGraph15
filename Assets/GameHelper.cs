using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHelper : MonoBehaviour
{
    public InputField input;
    public Text text;

    private PlayerHelper _currentPlayer;
    public PlayerHelper currentPlayer
    {
        get { return _currentPlayer; }
        set
        {
            _currentPlayer = value;
        }
    }
    
    public void Send()
    {
        currentPlayer.CmdSend(input.text);
    }
    
}
