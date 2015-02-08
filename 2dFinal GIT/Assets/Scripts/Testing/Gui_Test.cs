using UnityEngine;
using System.Collections;

public class Gui_Test : MonoBehaviour
{
    // we dont need to attach this script to camera. As Navdeep said just show something on the screen. SO I just 
    // added this Gui_Test to camera for testing purpose and created 2 UserStats object and passed some data.


    private UserStats player1,player2;

	void Start ()
	{
        // since we will allow 4 player to connect therefore we can just create 4 user stats on any script 
        // and modify values using proerties. 

        //nPlayer = new Userstats(float hp,float def,float mSpeed,float jStat,float dStat,string pName,bool wLoss,float aSpeed)

		player1 = new UserStats(45,20,23,12,32,"Red Guy",true,32);
        player2 = new UserStats(20, 10, 40, 00, 12, "Bowser", true, 22);
	}
	
	void Update () {

	}

    void OnGUI()
    {

        /////////////////// 1st player ////////////
       
       
        GUILayout.BeginArea(new Rect(10, 10, 180, Screen.width / 2));
        GUILayout.BeginVertical("box");

        GUILayout.Label("Player Name: "+player1.PlayerName);
        GUILayout.Label("Health Power: " + player1.HealthPower);
        GUILayout.Label("Defence: "+player1.Defence);
        GUILayout.Label("Move Speed: "+player1.MoveSpeed);
        GUILayout.Label("Jump: "+player1.JumpStats);
        GUILayout.Label("Demage: "+player1.DemageStats);
        GUILayout.Label("win/lose: "+player1.WinLoss);
        GUILayout.Label("Atacking Speed: "+player1.AttackingSpeed);

        GUILayout.EndVertical();
        GUILayout.EndArea();

        /////////////////// 2nd player ////////////
        
        GUILayout.BeginArea(new Rect(200, 10, 180, Screen.width / 2));
        GUILayout.BeginVertical("box");

        GUILayout.Label("Player Name: " + player2.PlayerName);
        GUILayout.Label("Health Power: " + player2.HealthPower);
        GUILayout.Label("Defence: " + player2.Defence);
        GUILayout.Label("Move Speed: " + player2.MoveSpeed);
        GUILayout.Label("Jump: " + player2.JumpStats);
        GUILayout.Label("Demage: " + player2.DemageStats);
        GUILayout.Label("win/lose: " + player2.WinLoss);
        GUILayout.Label("Atacking Speed: " + player2.AttackingSpeed);

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

}
