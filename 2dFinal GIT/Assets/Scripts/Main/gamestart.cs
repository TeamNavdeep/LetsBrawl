
using UnityEngine;
using System.Collections;

public class gamestart : MonoBehaviour 
{		
	// Our Startscreen GUI
	GameObject customizeMenu,GUIButton;

	void Start(){
		customizeMenu = GameObject.Find("CustomizeMenu");
		GUIButton = GameObject.Find("GUI");
		customizeMenu.SetActive(false);
	}

	public void BackButton(){
		customizeMenu.SetActive(false);
		GUIButton.SetActive(true);
	}

	void OnGUI () 
	{
		if(GUI.Button(new Rect (Screen.width/2 - 75, Screen.height/2, 150, 30), "Play Game"))
		{
			startGame();
		}	
		if (GUI.Button (new Rect (Screen.width/2 - 75, Screen.height/2 + 35, 150, 30), "Customize Character"))
		{
			customizeMenu.SetActive(true);
			GUIButton.SetActive(false);
		}
		if (GUI.Button (new Rect (Screen.width/2 - 75, Screen.height/2 + 70, 150, 30), "Achievements"))
		{
			Achievements();
		}
	}
	
	private void startGame()
	{
		//Launch Louis Script
		print("Starting game scene");
		
		DontDestroyOnLoad(gamestate.Instance);
		gamestate.Instance.startState();
	}

	private void Achievements()
	{
		print("Achievements scene");
		
		DontDestroyOnLoad(gamestate.Instance);
		gamestate.Instance.startState();
	}
}
