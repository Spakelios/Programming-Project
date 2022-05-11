using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    private int score;

    private GameStatus gs = new GameStatus();
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        
    }

    public void ChangeScore(int dropValue)
    {
        gs.coins += dropValue;
        text.text = "X" + gs.coins;
    }
}