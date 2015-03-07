using UnityEngine;
using System.Collections;

public class gamestate : MonoBehaviour {


	// Declare properties
	private static gamestate instance;
	private string activeLevel;			
	private float healthPower,defence,moveSpeed,jumpStats,demageState,attackingSpeed;
	private string playerName;
	private bool winLoss;
	UserStats userProp = new UserStats();
	
	// ---------------------------------------------------------------------------------------------------
	// gamestate()
	// --------------------------------------------------------------------------------------------------- 
	// Creates an instance of gamestate as a gameobject if an instance does not exist
	// ---------------------------------------------------------------------------------------------------
	public static gamestate Instance
	{
		get
		{
			if(instance == null)
			{
				instance =  new GameObject("gamestate").AddComponent<gamestate>();
			}
			
			return instance;
		}
	}	
	
	// Sets the instance to null when the application quits
	public void OnApplicationQuit()
	{
		instance = null;
	}
	// startState()
	// --------------------------------------------------------------------------------------------------- 
	// Creates a new game state
	// ---------------------------------------------------------------------------------------------------
	public void startState()
	{
		print ("Creating a new game state");

		// Set default properties:
		activeLevel = "Level 1";
		playerName = userProp.PlayerName;
		healthPower = userProp.HealthPower;
		defence = userProp.Defence;
		moveSpeed = userProp.MoveSpeed;
		jumpStats = userProp.JumpStats;
		demageState = userProp.DemageStats;
		attackingSpeed = userProp.AttackingSpeed;
			
		Application.LoadLevel("network_test");
	}
}
