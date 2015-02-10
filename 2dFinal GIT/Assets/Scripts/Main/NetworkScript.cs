using UnityEngine;
using System.Collections;

public class NetworkScript : MonoBehaviour {

	//Global Objects/Variables
	public GUISkin skinGUI;
	public string gameName = "Let's Brawl ver 0.4";//Name of the Game
	public string serverName = "Game Match";//Custom name of the server
	public string hostName = "Louis";//Host Name
	private string password = "";
	private bool wantPass = false;
	private string errorMessage = "";

	private bool refreshing = true;
	private HostData[] hData = new HostData[6];
	private string waitMsg = "";

	public GameObject player;
	public GameObject startPos;
	
	void startServer(){
		if (serverName == null || serverName == "")
			errorMessage = "Enter a name in the Server Name field.";
		else if (wantPass && password == "")
			errorMessage = "Enter a Password";
		else{
			if (wantPass)
				Network.incomingPassword = password;
			Network.InitializeServer (3, 25001, !Network.HavePublicAddress());//Number of players, port number, makes sure the port isn't taken
			MasterServer.RegisterHost (gameName, serverName, hostName);
			Debug.Log("Starting Server");
		}
	}
	
	void refreshHostList(){
		MasterServer.RequestHostList (gameName);
		refreshing = true;
		for (int i = 0; i < hData.Length; i++){
			hData[i] = null;
		}
	}

	void createPlayer(){
		if (Network.isServer){
			Network.Instantiate (player, startPos.transform.position, player.transform.rotation, 0);
		}
		else if (Network.isClient)
			Network.Instantiate (player, startPos.transform.position, player.transform.rotation, 1);
	}

	void Update () {
		if (refreshing){
			if (MasterServer.PollHostList().Length > 0){
				refreshing = false;
				Debug.Log(MasterServer.PollHostList ().Length);
				hData = MasterServer.PollHostList ();
				waitMsg = "";
			}
			else{
				waitMsg = "Finding Games...";
			}
		}
		else{
			if (MasterServer.PollHostList().Length <= 0){
				waitMsg = "Can't Find Games";
			}
		}
	}

	void OnServerInitialized(){
		Debug.Log ("Server Initialized");
		createPlayer ();
	}

	void OnConnectedToServer(){
		createPlayer ();
	}

	void OnDisconnectedFromServer(){
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		for (int i = 0; i < players.Length; i++){
			Destroy(players[i]);
		}
	}
	
	void OnMasterServerEvent(MasterServerEvent mse){
		if(mse == MasterServerEvent.RegistrationSucceeded)
			Debug.Log("Registered Server!");
		else{
			errorMessage = "Server already taken.";
			Debug.Log("Registration Failed");
		}
	}
	
	void OnGUI(){
		Rect hg1 = new Rect (0, 0, Screen.width / 2, Screen.height);
		Rect info = new Rect (hg1.width / 2 - ((hg1.width - 50) / 2), 100, hg1.width - 100, hg1.height - 400);
		
		GUI.skin = skinGUI;
		if (!Network.isServer && !Network.isClient){
			GUI.BeginGroup (hg1);//Gives the GUI a default size
			GUI.Box (new Rect(0, 0, hg1.width, hg1.height), "Host Game");
			GUI.BeginGroup (info);
			GUI.Label (new Rect (20, 20, 80, 20), "Server Name:");
			serverName = GUI.TextField (new Rect(100, 20, 200, 20), serverName, 25);
			
			wantPass = GUI.Toggle (new Rect (20, 50, 80, 20), wantPass, "Password");
			
			if (wantPass){
				GUI.Label(new Rect(20, 70, 100, 20), "Enter Password:");
				password = GUI.PasswordField(new Rect(120, 70, 150, 20), password, '#', 15);
			}
			GUI.Label (new Rect (20, info.height - 80, info.width - 40, 20), errorMessage);
			
			Rect btnSize1 = new Rect (info.width / 2 - 50, info.height - 50, 100, 50);
			GUI.EndGroup ();
			
			if (GUI.Button(new Rect(hg1.width / 2 - 100, hg1.height - 150, 200, 100), "Start Server")){
				startServer();
			}
			
			GUI.EndGroup ();
		}
		else{
			
		}

		Rect hg2 = new Rect (Screen.width / 2, 0, Screen.width / 2, Screen.height);

		if (!Network.isServer && !Network.isClient){
			GUI.BeginGroup (hg2);
			GUI.Box (new Rect (0, 0, hg2.width, hg2.height), "Join Game");
			
			if (GUI.Button(new Rect(20, 20, 80, 40), "Refresh")){
				refreshHostList();
				Debug.Log("Refresh");
			}
			GUI.Label (new Rect (hg2.width / 2 - 50, hg2.height / 2 - 10, 100, 20), waitMsg);
			Rect gameBox;
			if (!refreshing){
				for (int i = 0; i < hData.Length; i++){
					if (hData[i] != null){
						gameBox = new Rect (hg2.width / 2 - ((hg2.width - 200) / 2), 60 + (60 * i), hg2.width - 200, 60);
						GUI.BeginGroup(gameBox);
						GUI.Box(gameBox, "" + (1 + 1));
						GUI.Label(new Rect(gameBox.width / 2 - 100, gameBox.height / 2 - 10, 200, 20), hData[i].gameName);
						GUI.Label(new Rect(20, 10, 200, 20), "Host: " + hData[i].comment);
						GUI.Label(new Rect(20, gameBox.height - 30, 50, 20), hData[i].connectedPlayers + "/" + hData[i].playerLimit);
						if (GUI.Button(new Rect(gameBox.width - 100, 0, 40, 40), "Join")){
							if (hData[i].passwordProtected){
								
							}
							else{
								Network.Connect(hData[i]);
							}
						}
						GUI.EndGroup();
					}
				}
			}
			
			if (GUI.Button(new Rect(hg2.width / 2 - 100, hg2.height - 150, 200, 100), "Menu")){
				Application.LoadLevel("GameSelection");
			}
			
			GUI.EndGroup ();
		}
		if (Network.isServer){
			if (GUI.Button(new Rect(20, 20, 200, 100), "Close Server")){
				Network.Disconnect();
			}
		}
		if (Network.isClient){
			if (GUI.Button(new Rect(20, 20, 200, 100), "Disconnect")){
				Network.Disconnect();
			}
		}
	}
}
