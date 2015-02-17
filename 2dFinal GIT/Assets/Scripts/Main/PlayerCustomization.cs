using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlayerCustomization 
{
    public static int totalAttack, totalDefence, totalSpeed;

    public enum Attack
    {
        PowerGloves,BrawnBadge,XAttack
    }
    public enum Defence
    {
        ProtectionBadge,Jacket,Suit,Helmet
    }
    public enum Speed
    {
        AgilityBadge,Boots,Booster,Shoes
    }

    public int[] EquipAttack(Attack att)
    {
        switch (att)
        {
            case Attack.PowerGloves:
                totalAttack += 85;
                totalDefence -= 35;
                break;
            case Attack.BrawnBadge:
                totalAttack += 45;
                totalDefence -= 25;
                break;
            case Attack.XAttack:
                totalAttack += 65;
                totalDefence -= 45;
                break;
        }
        return new int[] { totalAttack, totalDefence}; // returning 2 values final attack , final defence 
    }

    public int[] EquipDefence(Defence def)
    {
        switch (def)
        {
            case Defence.Helmet:
                totalDefence += 55;
                totalSpeed -=  25;
                break;
            case Defence.Jacket:
                totalDefence += 85;
                totalSpeed -= 35;
                break;
            case Defence.ProtectionBadge:
                totalDefence += 45;
                totalSpeed -= 22;
                break;
            case Defence.Suit:
                totalDefence += 65;
                totalSpeed -= 30;
                break;
        }
        return new int[] {totalDefence, totalSpeed}; // returning two values |  final defence and final speed;
    }
    public int[] EquipSpeed(Speed spd)
    {
        switch (spd)
        {
            case Speed.AgilityBadge:
                totalSpeed += 55;
                totalAttack -= 20;
                break;
            case Speed.Booster:
                totalSpeed += 70;
                totalAttack -= 45;
                break;
            case Speed.Boots:
                totalSpeed += 40;
                totalAttack-= 35;
                break;
            case Speed.Shoes:
                totalSpeed += 35;
                totalAttack -= 35;
                break;
        }
        return new int[] { totalSpeed, totalAttack };  // returning two values |  final speed and final attack
    }

//    void Start ()
//    {
//
//        //Debug.Log("First I choose helmet from  defence equipment - Final Defence: " + EquipDefence(Defence.Helmet)[0]);
//
//        //Debug.Log("second I choose boots from Speed equipment - Final Speed: " + EquipSpeed(Speed.Boots)[0]);
//
//        EquipAttack(Attack.XAttack);
//        EquipDefence(Defence.Helmet);
//        EquipSpeed(Speed.Booster);
//
//        Debug.Log("Total Attack : " + totalAttack);
//        Debug.Log("Total speed : " + totalSpeed);
//        Debug.Log("Total defense: " + totalDefence);
//
//    }
//	
//	void Update () {
//	
//	}

}
