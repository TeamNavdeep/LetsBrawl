using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

	GameObject[] platformsobj;

	public Transform platform;

	private bool isServer = false, isClient = false;


	//private Vector3 lfstplatform, mfstplatform, rfstplatform;
	private Vector3 lsndplatform, msndplatform, rsndplatform;
	private Vector3 ltrdplatform, mtrdplatform, rtrdplatform;
	private Vector3 lfthplatform, mfthplatform, rfthplatform;

	void GeneratePlatform(){
		platformsobj = GameObject.FindGameObjectsWithTag ("Platform");

		// Upper most platforms
		//lfstplatform = new Vector3 (-4.35f, 8f, -13.5f);
		//mfstplatform = new Vector3 (0, 8f, -12.5f);
		//rfstplatform = new Vector3 (4.35f, 8f, -13.5f);

		// 2nd Upper platforms
		lsndplatform = new Vector3 (-7.35f, 8f, -12f);
		msndplatform = new Vector3 (0, 8f, -12f);
		rsndplatform = new Vector3 (7.35f, 8f, -12f);

		// 3rd lower most platforms
		ltrdplatform = new Vector3 (-7.35f, 5f, -12f);
		mtrdplatform = new Vector3 (0, 5f, -12f);
		rtrdplatform = new Vector3 (7.35f, 5f, -12f);

		// 4th lowest most platforms
		lfthplatform = new Vector3 (-7.35f, 0f, -12f);
		mfthplatform = new Vector3 (0, 0f, -12f);
		rfthplatform = new Vector3 (7.35f, 0f, -12f);

		//int fstplatformrng = Random.Range (0,50);
		int sndplatformrng = Random.Range (0,50);
		int trdplatformrng = Random.Range (0,50);
		int fthplatformrng = Random.Range (0,50);
		int slantedplatformrng = Random.Range(0, 10);
		//int platformpicker = 0;
		int platformpicker2 = 0;
		int platformpicker3 = 0;
		int platformpicker4 = 0;

		/*
		// First Row	
		if (fstplatformrng > 20) {
			Debug.Log ("Spawning 1st row platform");
			platformpicker = Random.Range (1,4);
			switch(platformpicker)
			{
				case 1:
					if(CheckPlatforms(lfstplatform) == true){
						slantedplatformrng = Random.Range (0, 10);
						if(slantedplatformrng >= 5){
							Network.Instantiate(platform, lfstplatform, Quaternion.identity);
						}else{
							Network.Instantiate(platform, lfstplatform, Quaternion.Euler(0,0,-10));
						}
					}
					break;
				case 2:
					if(CheckPlatforms(mfstplatform) == true){
						Network.Instantiate(platform, mfstplatform, Quaternion.identity);
					}
					break;
				case 3:
					if(CheckPlatforms(rfstplatform) == true){
						slantedplatformrng = Random.Range (0, 10);
						if(slantedplatformrng >= 5){
							Network.Instantiate(platform, rfstplatform, Quaternion.identity);
						}else{
							Network.Instantiate(platform, rfstplatform, Quaternion.Euler(0,0,10));
						}
					}
					break;
			}
			Debug.Log ("1st Row = " + platformpicker);
		}
		*/

		// Second Row
		if (sndplatformrng > 10) {
			Debug.Log ("Spawning 2nd row platform");
			platformpicker2 = Random.Range (1,4);
			switch(platformpicker2)
			{
			case 1:
				if(CheckPlatforms(lsndplatform)==true)
				{
					slantedplatformrng = Random.Range (0, 10);
					if(slantedplatformrng >= 5){
						Network.Instantiate(platform, lsndplatform, Quaternion.identity, 0);
					}else{
						Network.Instantiate(platform, lsndplatform, Quaternion.Euler(0,0,-10), 0);
					}
				}else{
					if(CheckPlatforms(msndplatform)==true){
						platformpicker2 = 2;
						Network.Instantiate(platform, msndplatform, Quaternion.identity, 0);
					}
				}
				break;
			case 2:
				if(CheckPlatforms(msndplatform)==true)
				{
					Network.Instantiate(platform, msndplatform, Quaternion.identity, 0);
				}else if(CheckPlatforms(rsndplatform)==true){
					platformpicker2 = 3;
					Network.Instantiate(platform, rsndplatform, Quaternion.identity, 0);
				}else if(CheckPlatforms(lsndplatform)==true){
					platformpicker2 = 1;
					Network.Instantiate(platform, lsndplatform, Quaternion.identity, 0);
				}
				break;
			case 3:
				if(CheckPlatforms(msndplatform)==true)
				{
					//platformpicker = 3;
					Network.Instantiate(platform, msndplatform, Quaternion.identity, 0);
				}else if(CheckPlatforms(rsndplatform)==true){
					slantedplatformrng = Random.Range (0, 10);
					if(slantedplatformrng >= 5){
						Network.Instantiate(platform, rsndplatform, Quaternion.identity, 0);
					}else{
						Network.Instantiate(platform, rsndplatform, Quaternion.Euler(0,0,10), 0);
					}
				}
				break;
			}
			Debug.Log ("2nd Row = " + platformpicker2);
		}

		// Third Row
		if (trdplatformrng > 10) {
			Debug.Log ("Spawning 3rd row platform");
			platformpicker3 = Random.Range (1,4);
			switch(platformpicker3)
			{
			case 1:
				if(platformpicker2 != 1 && CheckPlatforms(ltrdplatform)==true)
				{
					slantedplatformrng = Random.Range (0, 10);
					if(slantedplatformrng >= 5){
						Network.Instantiate(platform, ltrdplatform, Quaternion.identity, 0);
					}else{
						Network.Instantiate(platform, ltrdplatform, Quaternion.Euler(0,0,-10), 0);
					}
				}else{
					if(CheckPlatforms(mtrdplatform)==true){
						platformpicker3 = 2;
						Network.Instantiate(platform, mtrdplatform, Quaternion.identity, 0);
					}
				}
				break;
			case 2:
				if(platformpicker2 != 2 && CheckPlatforms(mtrdplatform)==true)
				{
					Network.Instantiate(platform, mtrdplatform, Quaternion.identity, 0);
				}else if(platformpicker2 == 1){
					if(CheckPlatforms(rtrdplatform)==true){
						platformpicker3 = 3;
						Network.Instantiate(platform, rtrdplatform, Quaternion.identity, 0);
					}
				}else{
					if(CheckPlatforms(ltrdplatform)==true){
						platformpicker3 = 1;
						Network.Instantiate(platform, ltrdplatform, Quaternion.identity, 0);
					}
				}
				break;
			case 3:
				if(platformpicker2 == 3 && CheckPlatforms(mtrdplatform)==true)
				{
					platformpicker3 = 3;
					Network.Instantiate(platform, mtrdplatform, Quaternion.identity, 0);
				}else{
					if(CheckPlatforms(rtrdplatform)==true){
						slantedplatformrng = Random.Range (0, 10);
						if(slantedplatformrng >= 5){
							Network.Instantiate(platform, rtrdplatform, Quaternion.identity, 0);
						}else{
							Network.Instantiate(platform, rtrdplatform, Quaternion.Euler(0,0,10), 0);
						}
					}
				}
				break;
			}
			Debug.Log ("3rd Row = " + platformpicker3);
		}

		// Fourth Row
		if (fthplatformrng > 10) {
			Debug.Log ("Spawning 4th row platform");
			platformpicker4 = Random.Range (1,4);
			switch(platformpicker4)
			{
			case 1:
				if(platformpicker3 != 1 && CheckPlatforms(lfthplatform)==true)
				{
					Network.Instantiate(platform, lfthplatform, Quaternion.identity, 0);
				}else{
					if(CheckPlatforms(mfthplatform)==true){
						platformpicker4 = 2;
						Network.Instantiate(platform, mfthplatform, Quaternion.identity, 0);
					}
				}
				break;
			case 2:
				if(platformpicker3 != 2 && CheckPlatforms(mfthplatform)==true)
				{
					Network.Instantiate(platform, mfthplatform, Quaternion.identity, 0);
				}else if(platformpicker3 == 1 || platformpicker2 == 1){
					if(CheckPlatforms(rfthplatform)==true){
						platformpicker4 = 3;
						Network.Instantiate(platform, rfthplatform, Quaternion.identity, 0);
					}
				}else{
					if(CheckPlatforms(lfthplatform)==true){
						platformpicker4 = 1;
						Network.Instantiate(platform, lfthplatform, Quaternion.identity, 0);
					}
				}
				break;
			case 3:
				if(platformpicker3 == 3 && CheckPlatforms(mfthplatform)==true)
				{
					platformpicker4 = 3;
					Network.Instantiate(platform, mfthplatform, Quaternion.identity, 0);
				}else{
					if(CheckPlatforms(rfthplatform)==true){
						Network.Instantiate(platform, rfthplatform, Quaternion.identity, 0);
					}
				}
				break;
			}
			Debug.Log ("4th Row = " + platformpicker4);
		}
	}

	void DestroyPlatforms(){
		platformsobj = GameObject.FindGameObjectsWithTag ("Platform");
		Debug.Log ("Removing Platforms");
		foreach (GameObject item in platformsobj) {
			Destroy (item);
		}
	}

	bool CheckPlatforms(Vector3 chosenplatform){
		bool isfree = true;
		platformsobj = GameObject.FindGameObjectsWithTag ("Platform");
		if(platformsobj.Length > 0){
			for (int i=0; i < platformsobj.Length; i++){
				if(platformsobj[i].transform.position.x == chosenplatform.x &&
				   platformsobj[i].transform.position.y == chosenplatform.y &&
				   platformsobj[i].transform.position.z == chosenplatform.z){
					isfree = false;
					Debug.Log ("Detected overlapping on " + chosenplatform.x + " " + chosenplatform.y + " " + chosenplatform.z);
					Debug.Log ("There are " + platformsobj.Length + " left");
				}
			}
		}
		return isfree;
	}

	// Use this for initialization
	void Start () {
		// REMOVE ORIENTATION LINE UNDER THIS COMMENT UPON MERGING
		Screen.orientation = ScreenOrientation.Landscape;

		platformsobj = GameObject.FindGameObjectsWithTag ("Platform");
		// Generate the platforms
		//TotalPlatforms ();

	}

	void TotalPlatforms(){
		platformsobj = GameObject.FindGameObjectsWithTag ("Platform");

		while(GameObject.FindGameObjectsWithTag("Platform").Length <= 3){
			Debug.Log ("Less than 4 platforms!");
			GeneratePlatform();
			platformsobj = GameObject.FindGameObjectsWithTag ("Platform");
		}

		platformsobj = GameObject.FindGameObjectsWithTag ("Platform");

		Debug.Log ("Platforms total is " + platformsobj.Length);
		foreach (GameObject item in platformsobj) {
			Debug.Log ("Platform: X=" + item.transform.position.x + " Y=" + item.transform.position.y + " Z=" + item.transform.position.z);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Network.isServer){
			if (Input.GetKeyDown (KeyCode.T) || !isServer) {
				Debug.Log ("Creating Level!!");
				TotalPlatforms();
				isServer = true;
			}
			// Reset the levels debug key
			if (Input.GetKeyDown (KeyCode.R)) {
				Debug.Log ("Destroying level!!");
				DestroyPlatforms();
			}
		}
		else{
			if (isServer){
				Debug.Log ("Destroying level!!");
				DestroyPlatforms();
				isServer = false;
			}
		}
		if (Network.isClient){
			isClient = true;
		}
		else{
			if (isClient){
				Debug.Log ("Destroying level!!");
				DestroyPlatforms();
				isClient = false;
			}
		}
	}
}
