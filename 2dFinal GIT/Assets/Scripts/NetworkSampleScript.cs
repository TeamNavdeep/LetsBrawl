using UnityEngine;
using System.Collections;

public class NetworkSampleScript : MonoBehaviour {
	
	//Global Objects/Variables
	public string gameName = "CGCookie_Tutorial_Networking";

	private bool refreshing = false;
	private HostData[] hostData;

	void startServer(){
		Network.InitializeServer (4, 25001, !Network.HavePublicAddress());
		MasterServer.RegisterHost (gameName, "Super Awesome Game", "This game is going to be awesome");
	}

	void refreshHostList(){
		MasterServer.RequestHostList (gameName);
	}

	void OnServerInitialized(){
		Debug.Log ("Server Initialized");
	}

	void OnMasterServerEvent(MasterServerEvent mse){
		if(mse == MasterServerEvent.RegistrationSucceeded){
			Debug.Log("Registed Server!");
		}
	}

	void Update(){
		if (MasterServer.PollHostList().Length > 0){
			refreshing = true;
			Debug.Log(MasterServer.PollHostList ().Length);
			hostData = MasterServer.PollHostList ();
		}
	}
	//GUI
	void OnGUI(){
		if (!Network.isClient && !Network.isServer){
			Rect btnSize1 = new Rect (5, 5, Screen.width / 6, Screen.height / 10);
			if(GUI.Button(btnSize1, "Start Server")){
				Debug.Log("Starting Server");
				startServer();
			}
			Rect btnSize2 = new Rect (5, 55, Screen.width / 6, Screen.height / 10);
			if(GUI.Button(btnSize2, "Refresh Hosts")){
				Debug.Log("Refreshing");
				refreshHostList();
			}
//			if (hostData.Length > 0){
//				for (int i = 0; i < hostData.Length; i++){
//					if(GUI.Button(new Rect(Screen.width - 50, 5 * (50 * i), Screen.width / 6, Screen.height / 10), hostData[i].gameName)){
//						Network.Connect(hostData[i]);
//					}
//				}
//			}
		}
	}
}
