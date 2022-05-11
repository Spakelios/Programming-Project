using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class buttons : MonoBehaviour
{
    public GameObject box;
    public GameObject player;
    public GameObject battle;
    public GameObject ui;
    public GameObject victory;
    
    public void startGame()
    {
        SceneManager.LoadScene("PROTOTYPE");
    }

    public void enterName()
    {
        box.SetActive(true);
    }

    public void finishBattle()
    {
        player.SetActive(true);
        battle.SetActive(false);
        ui.SetActive(true);
        victory.SetActive(false);
    }
}
