using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Stats : MonoBehaviour
{
    
    public float timer = 0;
    public static int minutes = 0;
    public static int seconds = 0;
    public Text balance;
    public static String endBalance;
    public static String spentGold;
    public int getBalance;
    public static String gameTime;
    public objectTrigger trigger;
    public static int coins;


    //When user finish map then get every stats like, time, spent gold, curent balance etc


    public void OnTriggerEnter(Collider other)
    {
        endBalance = balance.text;
        minutes = (int)(timer / 60);
        seconds = (int)(timer % 60);
        spentGold = (MoneyAndStats.balance - Int32.Parse(balance.text)).ToString();
        gameTime = minutes + " min " + seconds + " sec";
        MoneyAndStats.coinsBalance += MoneyAndStats.coins;

        switch (MoneyAndStats.level)
        {
            case "EASY":
                MoneyAndStats.mapOneEasy = false;
                break;
            case "MEDIUM":
                MoneyAndStats.mapOneMedium = false;
                break;
            case "HARD":
                MoneyAndStats.mapOneHard = false;
                break;
        }
    }

    void Update()
    {
        if (!trigger.finish)
        {
            timer += Time.unscaledDeltaTime;
        }

    }
    
}
