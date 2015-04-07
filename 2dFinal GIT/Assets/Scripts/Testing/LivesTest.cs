using UnityEngine;
using System.Collections;

public class LivesTest : MonoBehaviour {

    private BattleResultsManager brmScript;

	// Use this for initialization
	void Start () {
        brmScript = GetComponent<BattleResultsManager>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.F6))
        {
            brmScript.setPlayerLives(brmScript.getPlayerLives() - 1);
        }
	}
}
