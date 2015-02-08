using UnityEngine;
using System.Collections;

public class gamestate : MonoBehaviour {


	// Declare properties
	private static gamestate instance;
	private string activeLevel;			
	private string name;					
	private int maxHP;					
	private int maxMP;				
	private int hp;					
	private int mp;						
	private int str;						
	private int vit;							
	private int dex;						
	private int exp;

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
				//instance = new GameObject("gamestate").AddComponent();
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
		name = "My Character";
		maxHP = 250;
		maxMP = 60;
		hp = maxHP;
		mp = maxMP;
		str = 6;
		vit = 5;
		dex = 7;
		exp = 0;

		//Application.LoadLevel("level1");
	}
}
