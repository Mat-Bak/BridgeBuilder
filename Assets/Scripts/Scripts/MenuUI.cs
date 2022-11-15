using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class MenuUI : MonoBehaviour
{
    public GameObject menuWindow;
    public GameObject upgradesWindow;
    public GameObject mapsWindow;
    public GameObject levelsWindow;
    public GameObject HelpWindow;
    public Text testText;
    public static String balance = "0";
    public GameObject optionsWindow;
    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;
    private Color finishedLevel = new Color((float)1, (float)0.8, (float)0);
    private Color startLevel = new Color((float)0, (float)1, (float)0.2);



    void Awake()
    {
        testText.text = balance;
        
    }

    // Select map one or map two
    public void Play()
    {
        if(MoneyAndStats.selectMap == 1)
        {
            Application.LoadLevel("MapOne");
        }
        else if(MoneyAndStats.selectMap == 2)
        {
            Application.LoadLevel("MapTwo");
        }
        

    }


    //Each this methods are to hide or show individual windows in menu

    public void ShowMenuWindow()
    {
        menuWindow.SetActive(true);
        mapsWindow.SetActive(false);
        levelsWindow.SetActive(false);
        upgradesWindow.SetActive(false);
        optionsWindow.SetActive(false);
        HelpWindow.SetActive(false);
    }

    public void chooseMap()
    {
        menuWindow.SetActive(false);
        mapsWindow.SetActive(true);
        levelsWindow.SetActive(false);
        upgradesWindow.SetActive(false);
        optionsWindow.SetActive(false);
        HelpWindow.SetActive(false);

    }

    public void ShowLevelWindow(int map)
    {
        menuWindow.SetActive(false);
        mapsWindow.SetActive(false);
        levelsWindow.SetActive(true);
        upgradesWindow.SetActive(false);
        optionsWindow.SetActive(false);
        HelpWindow.SetActive(false);

        if (map == 1)
        {
            MoneyAndStats.selectMap = 1;
             if (MoneyAndStats.mapOneEasy == false)
             {
                easyButton.GetComponent<Image>().color = finishedLevel;
            }
            else
             {
                easyButton.GetComponent<Image>().color = startLevel;
            }
            if (MoneyAndStats.mapOneMedium == false)
             {
                mediumButton.GetComponent<Image>().color = finishedLevel;

             }
             else
             {
                mediumButton.GetComponent<Image>().color = startLevel;

             }
             if (MoneyAndStats.mapOneHard == false)
             {
                hardButton.GetComponent<Image>().color = finishedLevel;

             }
             else
             {
                hardButton.GetComponent<Image>().color = startLevel;

             }
            
        }
        else if(map == 2)
        {
            MoneyAndStats.selectMap = 2;
            if (MoneyAndStats.mapTwoEasy == false)
            {
                easyButton.GetComponent<Image>().color = finishedLevel;

            }
            else
            {
                easyButton.GetComponent<Image>().color = startLevel;

            }
            if (MoneyAndStats.mapTwoMedium == false)
            {
                mediumButton.GetComponent<Image>().color = finishedLevel;

            }
            else
            {
                mediumButton.GetComponent<Image>().color = startLevel;

            }
            if (MoneyAndStats.mapTwoHard == false)
            {
                hardButton.GetComponent<Image>().color = finishedLevel;

            }
            else
            {
                hardButton.GetComponent<Image>().color = startLevel;

            }
           
        }
        

    }

    public void ShowUpgradesWindow()
    {
        menuWindow.SetActive(false);
        mapsWindow.SetActive(false);
        levelsWindow.SetActive(false);
        upgradesWindow.SetActive(true);
        optionsWindow.SetActive(false);
        HelpWindow.SetActive(false);

        balance = (Int32.Parse(testText.text) + Stats.coins).ToString();
        Stats.coins = 0;

    }

    public void ShowHelpWindow()
    {
        HelpWindow.SetActive(true);
        menuWindow.SetActive(false);
        mapsWindow.SetActive(false);
        levelsWindow.SetActive(false);
        upgradesWindow.SetActive(false);
        optionsWindow.SetActive(false);
        
    }

    public void ShowOptionsWindow()
    {
        menuWindow.SetActive(false);
        mapsWindow.SetActive(false);
        levelsWindow.SetActive(false);
        upgradesWindow.SetActive(false);
        optionsWindow.SetActive(true);
        HelpWindow.SetActive(false);
    }

    public void setEasyLevel()
    {
        MoneyAndStats.level = "EASY";
        if (MoneyAndStats.selectMap == 1)
        {
            if (MoneyAndStats.mapOneEasy == true)
            {
                MoneyAndStats.coins = 5;
            }
            else
            {
                MoneyAndStats.coins = 0;
            }

        }
        else if (MoneyAndStats.selectMap == 2)
        {
            if (MoneyAndStats.mapTwoEasy == true)
            {
                MoneyAndStats.coins = 5;
            }
            else
            {
                MoneyAndStats.coins = 0;
            }
        }
        MoneyAndStats.balance = 9999999;
    }
    public void setMediumLevel()
    {
        if (MoneyAndStats.selectMap == 1)
        {
            if (MoneyAndStats.mapOneMedium == true)
            {
                MoneyAndStats.coins = 10;
            }
            else
            {
                MoneyAndStats.coins = 0;
            }

        }
        else if (MoneyAndStats.selectMap == 2)
        {
            if (MoneyAndStats.mapTwoMedium == true)
            {
                MoneyAndStats.coins = 10;
            }
            else
            {
                MoneyAndStats.coins = 0;
            }
        }
        MoneyAndStats.level = "MEDIUM";
        MoneyAndStats.balance = 8000;
    }
    public void setHardLevel()
    {
        if (MoneyAndStats.selectMap == 1)
        {
            if (MoneyAndStats.mapOneHard == true)
            {
                MoneyAndStats.coins = 15;
            }
            else
            {
                MoneyAndStats.coins = 0;
            }

        }
        else if (MoneyAndStats.selectMap == 2)
        {
            if (MoneyAndStats.mapTwoHard == true)
            {
                MoneyAndStats.coins = 15;
            }
            else
            {
                MoneyAndStats.coins = 0;
            }
        }
        MoneyAndStats.level = "HARD";
        MoneyAndStats.balance = 6000;
    }

    
    public void closeApplication()
    {
        Application.Quit();
    }
    






}
