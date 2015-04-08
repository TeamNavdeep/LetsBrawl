using UnityEngine;
using System.Collections;

public class BattleResultsManager : MonoBehaviour {

    public GameObject life01;
    public GameObject life02;
    public GameObject life03;

    private int playerLives = 3;
    private TestHealth thScript;
    private bool livesLeft;

	// Use this for initialization
	void Start () {
        livesLeft = true;
        thScript = GetComponent<TestHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		thScript.getAliveStatus();
        switch (playerLives)
        {
            case 0:
                life01.SetActive(false);
                life02.SetActive(false);
                life03.SetActive(false);
                break;
            case 1:
                life01.SetActive(true);
                life02.SetActive(false);
                life03.SetActive(false);
                break;
            case 2:
                life01.SetActive(true);
                life02.SetActive(true);
                life03.SetActive(false);
                break;
            case 3:
                life01.SetActive(true);
                life02.SetActive(true);
                life03.SetActive(true);
                break;
        }

        if (thScript.getAliveStatus() == false)
        {
            thScript.setAliveStatus(true);
            playerLives--;
        }

        if (playerLives <= 0)
        {
            livesLeft = false;
            Application.LoadLevel("Lose_Screen");
        }
	}

    public bool getLivesLeft()
    {
        return livesLeft;
    }

    public void setLivesLeft(bool newStatus)
    {
        livesLeft = newStatus;
    }

    //For testing only
    public void setPlayerLives(int newValue)
    {
        playerLives = newValue;
    }

    public int getPlayerLives()
    {
        return playerLives;
    }
}
