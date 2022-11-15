using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class SetStats : MonoBehaviour
{
    public Text level;
    public Text spent;
    public Text remaining;
    public Text time;
    public Text coins;
    public GameObject easyStats;
    public GameObject otherStats;

    //Set stats on the finish window when user finish map
    void Start()
    {
        if (MoneyAndStats.level == "EASY")
        {
            easyStats.SetActive(true);
            otherStats.SetActive(false);
        }
        else
        {
            easyStats.SetActive(true);
            otherStats.SetActive(true);
        }
        level.text = MoneyAndStats.level;
        spent.text = Stats.spentGold;
        remaining.text = Stats.endBalance;
        time.text = Stats.gameTime;
        coins.text = MoneyAndStats.coins.ToString();
        
        
    }

}
