using UnityEngine;
using System;
using System.IO;
using TMPro;

public class SaveGame : MonoBehaviour
{
    private Unit _unit = new Unit();
   
    public TextMeshProUGUI health;


    string filePath;
    const string FILE_NAME = "SaveGame.txt";
//this function emulates a random game event that changes the player life

//this function overrides the saving file
    public void SaveLifePoints ()
    {
        File.WriteAllText (filePath + "/" + FILE_NAME, Player.currentHealth.ToString ());
        File.WriteAllText (filePath + "/" + FILE_NAME, _unit.unitLevel.ToString ());

        
        Debug.Log ("File created and saved");
    }
    public void LoadLifePoints (){
//always check the file exists
        if (File.Exists (filePath + "/" + FILE_NAME))
        {
            Player.currentHealth = Int32.Parse (File.ReadAllText (filePath + "/" + FILE_NAME));
            _unit.unitLevel = Int32.Parse (File.ReadAllText (filePath + "/" + FILE_NAME));
            Debug.Log ("File loaded successfully");
        } 
        else 
        {
            Player.currentHealth = 0;
            Debug.Log ("File not found");
        }
    }
    
// Use this for initialization
    void Start (){
//retrieving saving location
        filePath = Application.persistentDataPath;
        Debug.Log (filePath);
//startup initialisation
        LoadLifePoints ();
    }
// Update is called once per frame
    void Update (){
        health.text = "HP: " + Player.currentHealth;

    }
}

