using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	//Global Objects/Variables
	public GameObject gameover;
	//multi touch support
	public static Touch[] touches;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){
		Rect hg1 = new Rect (0, 0, Screen.width / 2, Screen.height);
		Rect hg2 = new Rect (Screen.width / 2, 0, Screen.width / 2, Screen.height);
		Rect info = new Rect (hg1.width / 2 - ((hg1.width - 50) / 2), 100, hg1.width - 100, hg1.height - 400);

		if (GUI.Button(new Rect(hg2.width / 2 - 100, hg2.height - 150, 200, 100), "Menu")){
			Application.LoadLevel("MainMenu");
		}
	}
}