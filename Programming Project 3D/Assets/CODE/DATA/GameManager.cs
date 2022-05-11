using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using TMPro;


//game status data structure
[Serializable]
public struct GameStatus
{
	public int currentLevel;
	public List<Vector3> NPCs;
	public Vector3 playerPosition;
	public int coins;
}

// Create Game Class using the Singleton Pattern
public class GameManager : MonoBehaviour
{
	public GameObject player, rob, robot, robots, ro;
	// Declare Struct for GameStatus (HUD Data)
	public GameStatus gameStatus;

	// Variable for file path
	string filePath;

	// Variable for filename
	const string FILE_NAME = "SaveStatus.json";

	// Make a Public (single) instance of itself
	public static readonly GameManager instance = new GameManager();

	// Make a private Constructor - This means it can only be instantiated by itself
	private GameManager()
	{
	}

	// Create a readonly property that returns a reference to the single instance
	public static GameManager Instance
	{
		get { return instance; }
	}

	//build our UI controls- a simple label
	public string UpdateStatus()
	{
		//building the formatted string to be shown to the user
		string message = "";
		message += "Current Level: " + gameStatus.currentLevel + "\n";
		message += "NPC: " + gameStatus.NPCs;
		message += "Player: " + gameStatus.playerPosition;
		message += "Score: " + gameStatus.coins;
		return message;

	}

//this function overrides the saving file
	public void SaveGameStatus ()
	{
		//serialise the GameStatus struct into a Json string
		string gameStatusJson = JsonUtility.ToJson (gameStatus);
		File.WriteAllText (filePath + "/" + FILE_NAME, gameStatusJson);
		Debug.Log ("File created and saved");
		setState();
		UpdateStatus();
	}
	


	//this function loads a saving file if found
	public void LoadGameStatus ()
	{
		//always check the file exists
		if (File.Exists (filePath + "/" + FILE_NAME)) {
			//load the file content as string
			string loadedJson = File.ReadAllText (filePath + "/" + FILE_NAME);
			//deserialise the loaded string into a GameStatus struct
			gameStatus = JsonUtility.FromJson<GameStatus> (loadedJson);
			Debug.Log ("File loaded successfully");
			setState();
		} 
		else 
		{
			resetGame();
			Debug.Log("File not found");
		}
	}

	// Use this for initialization
	public void Start ()
	{
		//retrieving saving location
		filePath = Application.persistentDataPath;
		gameStatus = new GameStatus ();
		Debug.Log (filePath);
		//startup initialisation
		LoadGameStatus ();
	}

	public void setState()
	{ 
		gameStatus.currentLevel = 10;
		gameStatus.coins = 0;
		gameStatus.playerPosition = player.transform.position ;
		gameStatus.NPCs = new List<Vector3>()
		{
			robot.transform.position,
			robots.transform.position,
			ro.transform.position,
			rob.transform.position,
		};
	}
	public void resetGame()
	{
		
		gameStatus.currentLevel = 10;
		gameStatus.coins = 0;
		gameStatus.playerPosition = player.transform.position;;
		gameStatus.NPCs = new List<Vector3>()
		{
			robot.transform.position,
			robots.transform.position,
			ro.transform.position,
			rob.transform.position,
		};

		// Save initalisation scores
		SaveGameStatus();
	}
}        