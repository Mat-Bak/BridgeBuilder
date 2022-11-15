using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public objectTrigger trigger;
    public GameObject cameraMenuEasy;
    public GameObject cameraMenuMedium;
    public GameObject cameraMenuHard;

    // Set time to 1 if play button is clicked 
    // Change camera and allow user to move the car

    public void Play()
    {
        Time.timeScale = 1;
        if(MoneyAndStats.level == "EASY")
        {
            cameraMenuEasy.SetActive(true);
        }
        else if (MoneyAndStats.level == "MEDIUM")
        {
            cameraMenuMedium.SetActive(true);
        }
        else if (MoneyAndStats.level == "HARD")
        {
            cameraMenuHard.SetActive(true);
        }

        

    }
    public void Restart()
    {
        if (!trigger.finish) { 
            if(MoneyAndStats.selectMap == 0)
            {
                SceneManager.LoadScene("MapOne");
            }else if (MoneyAndStats.selectMap == 1)
            {
                SceneManager.LoadScene("MapTwo");
            }

            cameraMenuEasy.SetActive(false);
            cameraMenuMedium.SetActive(false);
            cameraMenuHard.SetActive(false);
        }
    }

    
   
}
