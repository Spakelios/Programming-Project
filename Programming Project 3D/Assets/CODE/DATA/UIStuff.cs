using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIStuff : MonoBehaviour
{
    public TextMeshProUGUI name;
    public TextMeshProUGUI level;
    

    private GameStatus GameStatus = new GameStatus();
    

    private void Start()
    {
        name.text = "Name: " + InputEntry.playerName;
        level.text = "LVL: " + GameStatus.currentLevel ;
    }
}
