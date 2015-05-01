using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class gamestart : MonoBehaviour 
{		
	// Our Startscreen GUI
	//healthPower being distributed to TestHealthPower, firerate changes firerate of each gun check player Controller switch
	//statement
	public static float healthPower = 100.00f;
	public static float fireRate;

	GameObject customizeMenu,GUIButton;
	Slider headGearSlider,chestGearSlider,glovesSlider,fireRateSlider;
	UserStats userStats = new UserStats();

	void Start(){
		customizeMenu = GameObject.Find("CustomizeMenu");
		GUIButton = GameObject.Find("GUI");
		customizeMenu.SetActive(false);
		//GUI.skin.label.fontSize = Screen.height / 1080 * 64;
	}

	public void BackButton(){
		customizeMenu.SetActive(false);
		GUIButton.SetActive(true);
	}

	void OnGUI () 
	{
		if(GUI.Button(new Rect (Screen.width/2 - 150, Screen.height/2 - 40, 290, 90), "<size=28>Play Game</size>"))
		{
			startGame();
		}	
		if (GUI.Button (new Rect (Screen.width/2 - 150, Screen.height/2 + 60, 290, 90), "<size=28>Customize Character</size>"))
		{
			customizeMenu.SetActive(true);

			headGearSlider = GameObject.Find("headGearSlider").GetComponent<Slider>();
			headGearSlider.onValueChanged.AddListener(HeadGearListener);

			chestGearSlider = GameObject.Find("chestGearSlider").GetComponent<Slider>();
			chestGearSlider.onValueChanged.AddListener(ChestGearListener);

			glovesSlider = GameObject.Find("glovesSlider").GetComponent<Slider>();
			glovesSlider.onValueChanged.AddListener(GlovesGearListener);

			fireRateSlider = GameObject.Find("fireRateSlider").GetComponent<Slider>();
			fireRateSlider.onValueChanged.AddListener(FireRateListener);
			
			GUIButton.SetActive(false);
		}
	}

	public void HeadGearListener(float value)
	{
		if(headGearSlider.value >= 0.7){
			chestGearSlider.value = 0.5f;
			glovesSlider.value = 0.2f;
			healthPower = 90;
		}
		if(headGearSlider.value <= 0.5){
			chestGearSlider.value = 0.6f;
			glovesSlider.value = 0.3f;
			healthPower = 80;
		}
	}
	public void ChestGearListener(float value)
	{
		if(chestGearSlider.value >= 0.7){
			headGearSlider.value = 0.5f;
			glovesSlider.value = 0.4f;
			healthPower = 90;
		}

	}
	public void GlovesGearListener(float value)
	{
		if(glovesSlider.value >= 0.7){
			chestGearSlider.value = 0.4f;
			headGearSlider.value = 0.3f;
			healthPower = 85;
		}
		if(glovesSlider.value <= 0.3){
			chestGearSlider.value = 0.6f;
			headGearSlider.value = 0.8f;
			healthPower = 80;
		}
	}
	public void FireRateListener(float value)
	{
		fireRate = fireRateSlider.value;
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
