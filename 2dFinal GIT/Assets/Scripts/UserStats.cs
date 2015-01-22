using System;
using UnityEngine;
using System.Collections;

public class UserStats
{

    private float healthPower,defence,moveSpeed,jumpStats,demageState,attackingSpeed;
    private string playerName;
    private bool winLoss;


    public UserStats(){}

    public UserStats(float hp,float def,float mSpeed,float jStat,float dStat,string pName,bool wLoss,float aSpeed)
    {
        healthPower = hp;
        defence = def;
        moveSpeed = mSpeed;
        jumpStats = jStat;
        demageState = dStat;
        playerName = pName;
        winLoss = wLoss;
        attackingSpeed = aSpeed;
    }

    public float HealthPower 
    {
        get { return healthPower; } 
        set { healthPower = value; } 
    }

	public float Defence {
	    get { return defence; }
	    set { defence = value; }
	}

	public float MoveSpeed{
	    get { return moveSpeed; }
	    set { moveSpeed = value; }
	}

    public float JumpStats {
        get { return jumpStats; }
        set { jumpStats = value; }
    }

	public float DemageStats {
	    get { return demageState; }
	    set { demageState = value; }
	}

    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; } 
    }

    public bool WinLoss {
        get { return winLoss; }
        set { winLoss = value; }
    }

	public float AttackingSpeed {
	    get { return attackingSpeed; }
	    set { attackingSpeed = value; }
	}



    
}
