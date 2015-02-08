
using UnityEngine;
using System.Collections;

public class gamestart : MonoBehaviour 
{		
	// Our Startscreen GUI

	void OnGUI () 
	{
		if(GUI.Button(new Rect (Screen.width/2 - 75, Screen.height/2, 150, 30), "Play Game"))
		{
			startGame();
		}	
		if (GUI.Button (new Rect (Screen.width/2 - 75, Screen.height/2 + 35, 150, 30), "Customize Character"))
		{
			print("Customize Character Meun");
		}
		if (GUI.Button (new Rect (Screen.width/2 - 75, Screen.height/2 + 70, 150, 30), "Achievements"))
		{
			print("Achievements");
		}
	}
	
	private void startGame()
	{
		print("Starting game");
		
		DontDestroyOnLoad(gamestate.Instance);
		gamestate.Instance.startState();
	}
}
