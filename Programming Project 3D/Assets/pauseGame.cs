using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class pauseGame : MonoBehaviour
{
    public GameObject pauseMenuUI;

  public void OnApplicationQuit()
    {
        Application.Quit();
        Debug.Log("quit");
    }
    
  public static bool GameIsPaused;

  // Update is called once per frame
  void Update()
  {

      if (Input.GetKeyDown(KeyCode.Escape))
      {
          if (GameIsPaused)
          {
              Resume();
          }
          else
          {
              Pause();
          }
      }
  }

  public void Resume()
  {
      pauseMenuUI.SetActive(false);
      Time.timeScale = 1f;
      GameIsPaused = false;
  }

  void Pause()

  {
      pauseMenuUI.SetActive(true);
      Time.timeScale = 0f;
      GameIsPaused = true;
  }
    
}