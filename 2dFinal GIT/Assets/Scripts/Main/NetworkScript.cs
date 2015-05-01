using UnityEngine;
using System.Collections;

public class NetworkScript : MonoBehaviour {

	//Global Objects/Variables
	public GUISkin skinGUI;
	public string gameName = "Let's Brawl ver 0.5";//Name of the Game
	public string serverName = "Game Match";//Custom name of the server
	public string hostName = "John";//Host Name
	private string password = "";//The password that the player enters
	private bool wantPass = false;//If the player hosting a game wants to add a password
	private string errorMessage = "";

	private bool refreshing = true, searching = false;
	private HostData[] hData = new HostData[6];
	private int minPortNum = 25001, maxPortNum = 25555;
	public int portNum = 25001;
	private bool taken = false;
	private string waitMsg = "";
	private int[] playerNum = new int[6];
	public int game;

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
			portNum = Random.Range(minPortNum, maxPortNum);
			Network.InitializeServer (3, portNum, !Network.HavePublicAddress());//Number of players, port number, makes sure the port isn't taken
			MasterServer.RegisterHost (gameName, serverName, hostName);
			Debug.Log("Starting Server");
		}
	}
	void startServer(int port){
		if (serverName == null || serverName == "")
			errorMessage = "Enter a name in the Server Name field.";
		else if (wantPass && password == "")
			errorMessage = "Enter a Password";
		else{
			if (wantPass)
				Network.incomingPassword = password;
			Network.InitializeServer (3, port, !Network.HavePublicAddress());//Number of players, port number, makes sure the port isn't taken
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

	void createPlayer(int playerNum){
		if (Network.isServer){
			Network.Instantiate (player, startPos.transform.position, player.transform.rotation, 0);
		}
		else if (Network.isClient)
			Network.Instantiate (player, startPos.transform.position, player.transform.rotation, playerNum);
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
				//refreshing = false;
			}
		}
		else{
			if (hData.Length <= 0){
				waitMsg = "Can't Find Games";
			}
			else{
				hData = MasterServer.PollHostList ();
			}
		}
	}

	void OnServerInitialized(){
		Debug.Log ("Server Initialized");
		createPlayer (game);
	}

	void OnConnectedToServer(){
		createPlayer (game);
	}

	void OnPlayerConnected(NetworkPlayer player){
		Debug.Log ("Player:" + player.port);
	}

	void OnPlayerDisconnected(NetworkPlayer player) {
		Debug.Log("Clean up after player " + player);
		Network.RemoveRPCs(player);
		Network.DestroyPlayerObjects(player);
	}

	void OnDisconnectedFromServer(){
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		GameObject[] hpBars = GameObject.FindGameObjectsWithTag("HP");
		for (int i = 0; i < players.Length; i++){
			Destroy(players[i]);
			Destroy(hpBars[i]);
		}
	}
	
	void OnMasterServerEvent(MasterServerEvent mse){
		if (searching){
			if(mse == MasterServerEvent.RegistrationSucceeded){
				taken = false;
				Debug.Log("Registered Server!");
				searching = false;
			}
			else{
				errorMessage = "Server already taken.";
				taken = true;
				Debug.Log("Registration Failed");
				startServer();
			}
		}
	}
	
	void OnGUI(){
		//Determined menu sizes
		Rect hg1 = new Rect (0, 0, Screen.width / 2, Screen.height);
		Rect hg2 = new Rect (Screen.width / 2, 0, Screen.width / 2, Screen.height);
		Rect info = new Rect (hg1.width / 2 - ((hg1.width - 50) / 2), 100, hg1.width - 100, hg1.height - 400);
		
		GUI.skin = skinGUI;
		//If you're not in a game
		if (!Network.isServer && !Network.isClient){
			GUI.BeginGroup (hg1);//Gives the GUI a default size
			GUI.Box (new Rect(0, 0, hg1.width, hg1.height), "Host Game");
			//Hosting game menu========================================================================================================
			GUI.BeginGroup (info);
			GUI.Label (new Rect (20, 20, 80, 20), "Server Name:");
			serverName = GUI.TextField (new Rect(100, 20, 200, 20), serverName, 25);
			//Toggle whether you want a password or not
			wantPass = GUI.Toggle (new Rect (20, 50, 80, 20), wantPass, "Password");
			//If you want a password with your game
			if (wantPass){
				GUI.Label(new Rect(20, 70, 100, 20), "Enter Password:");
				password = GUI.PasswordField(new Rect(120, 70, 150, 20), password, '#', 15);
			}
			GUI.Label (new Rect (20, info.height - 80, info.width - 40, 20), errorMessage);
			
			//Rect btnSize1 = new Rect (info.width / 2 - 50, info.height - 50, 100, 50);
			GUI.EndGroup ();
			
			if (GUI.Button(new Rect(hg1.width / 2 - 100, hg1.height - 150, 200, 100), "Start Server")){
				searching = true;
				startServer();
			}
			GUI.EndGroup ();
			//Finding game menu========================================================================================================
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
						gameBox = new Rect (hg2.width / 2 - ((hg2.width - 200) / 2), 60 + (60 * i), hg2.width - 50, 60);
						GUI.BeginGroup(gameBox);
						GUI.Box(gameBox, "" + (1 + 1));
						GUI.Label(new Rect(gameBox.width / 2 - 100, gameBox.height / 2 - 10, 200, 20), hData[i].gameName);
						GUI.Label(new Rect(20, 10, 200, 20), "Host: " + hData[i].comment);
						GUI.Label(new Rect(20, gameBox.height - 30, 50, 20), hData[i].connectedPlayers + "/" + hData[i].playerLimit);
						playerNum[i] = hData[i].connectedPlayers;
						if (GUI.Button(new Rect(gameBox.width - 100, 0, 40, 40), "Join")){
							if (hData[i].passwordProtected){
								//This is not important right now
							}
							else{
								game = playerNum[i];
								Network.Connect(hData[i]);
							}
						}
						GUI.EndGroup();
					}
				}
			}
			if (GUI.Button(new Rect(hg2.width / 2 - 100, hg2.height - 150, 200, 100), "Menu")){
				Application.LoadLevel("MainMenu");
			}
			GUI.EndGroup ();
			//End of game menu========================================================================================================
		}
		else{
			
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
