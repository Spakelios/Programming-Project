using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BattleTrigger : MonoBehaviour
{
    public GameObject loadingInterface;
    public Image loadingProgressBar;
    //List of the scenes to load from Main Menu
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
    public void StartGame()
    {
        ShowLoadingScreen();
        scenesToLoad.Add(SceneManager.LoadSceneAsync("PROTOTYPE"));
        scenesToLoad.Add(SceneManager.LoadSceneAsync("2", LoadSceneMode.Additive));
        StartCoroutine(LoadingScreen());
    }

    public void StartGameSo()
    {
        ShowLoadingScreen();
        StartCoroutine(LoadingScreen());
    }

    public void ShowLoadingScreen()
    {
        loadingInterface.SetActive(true);
    }

    IEnumerator LoadingScreen()
    {
        float totalProgress=0;
        //Iterate through all the scenes to load
        for(int i=0; i<scenesToLoad.Count; ++i)
        {
            while (!scenesToLoad[i].isDone)
            {
                //Adding the scene progress to the total progress
                totalProgress += scenesToLoad[i].progress;
                //the fillAmount needs a value between 0 and 1, so we devide the progress by the number of scenes to load
                loadingProgressBar.fillAmount = totalProgress/scenesToLoad.Count;
                yield return null;
            }
        }
    }
    
}