using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIStuff : MonoBehaviour
{
    public TextMeshProUGUI name;
    public Unit unit;
    public TextMeshProUGUI level;
    
    private void Start()
    {
        name.text= "Name: " + InputEntry.playerName;
        level.text = "LVL: " + unit.unitLevel;
    }
}
