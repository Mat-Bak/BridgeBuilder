using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    //Open MainMenu game 
    public void gameMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
