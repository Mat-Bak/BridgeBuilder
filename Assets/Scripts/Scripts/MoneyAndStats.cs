using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class MoneyAndStats : MonoBehaviour
{

    public static int roadCost = 50;
    public static int metalCost = 100;
    public static int balance = 10000;
    public Text textBalance;
    public Text textRoad;
    public Text textMetal;
    public GameObject balanceLabel;
    public static String level = "EASY";
    public static int coins;
    public static int coinsBalance = 0;
    public static float musicVolume = 1;
    public static bool mapOneEasy = true;
    public static bool mapOneMedium = true;
    public static bool mapOneHard = true;
    public static bool mapTwoEasy = true;
    public static bool mapTwoMedium = true;
    public static bool mapTwoHard = true;
    public static int selectMap;

    // Collects information on balance, level, money status, etc.

    void Start()
    {
        if(level == "EASY")
        {
            balanceLabel.SetActive(false);
        }
        else
        {
            balanceLabel.SetActive(true);
            textBalance.text = balance.ToString();
        }
        
        textRoad.text =  roadCost.ToString();
        textMetal.text = metalCost.ToString();


    }

}
