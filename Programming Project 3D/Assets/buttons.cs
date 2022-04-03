using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class buttons : MonoBehaviour
{
    public GameObject box;
    
    public void startGame()
    {
        SceneManager.LoadScene("PROTOTYPE");
    }

    public void enterName()
    {
        box.SetActive(true);
    }
}
