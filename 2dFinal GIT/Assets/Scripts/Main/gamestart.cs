using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class gamestart : MonoBehaviour 
{		
	// Our Startscreen GUI
	GameObject customizeMenu,GUIButton;
	Slider headGearSlider,chestGearSlider,glovesSlider;

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

			headGearSlider = GameObject.Find("headGearSlider").GetComponent<Slider>();
			headGearSlider.onValueChanged.AddListener(SliderListener);

			chestGearSlider = GameObject.Find("chestGearSlider").GetComponent<Slider>();
			chestGearSlider.onValueChanged.AddListener(SliderListener);

			glovesSlider = GameObject.Find("glovesSlider").GetComponent<Slider>();
			glovesSlider.onValueChanged.AddListener(SliderListener);
			
			GUIButton.SetActive(false);
		}
		if (GUI.Button (new Rect (Screen.width/2 - 75, Screen.height/2 + 70, 150, 30), "Achievements"))
		{
			Achievements();
		}
	}

	public void SliderListener(float value)
	{
		print("Head gear slider "+headGearSlider.value*100);
		print("Chest gear slider "+chestGearSlider.value*100);
		print("Gloves gear slider "+glovesSlider.value*100);
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
