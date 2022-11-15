using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class BuildMenu : MonoBehaviour
{
    public GameObject gameMenu;
    public GameObject gameOptionsPanel;
    public GameObject gameMenuPanel;
    private bool isOpen = false;

    //Menu in Game 



    //Open and close menu window
    public void openMenu()
    {
        if (!isOpen)
        {
            BarCreator.BuildMode = false;
            gameMenu.SetActive(true);
            gameMenuPanel.SetActive(true);
            isOpen = true;
        }
        else
        {
            BarCreator.BuildMode = true;
            gameMenu.SetActive(false);
            gameMenuPanel.SetActive(false);
            isOpen = false;
        }
        
    }

    // Go to Main Menu
    public void mainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    // Open options windown
    public void gameOptions()
    {
        gameMenuPanel.SetActive(false);
        gameOptionsPanel.SetActive(true);
    }

    // Exit game
    public void exitGame()
    {
        Application.Quit();
    }

    //Back to game
    public void backToGame()
    {
        gameMenu.SetActive(false);
        gameOptionsPanel.SetActive(false);
        gameMenuPanel.SetActive(false);
        BarCreator.BuildMode = true;
    }

    // Back to main menu window in game 
    public void backMenu()
    {
        gameOptionsPanel.SetActive(false);
        gameMenuPanel.SetActive(true);
    }
}
