using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUI : MonoBehaviour
{
    public GameObject Grid;
    public GameObject playButton;
    public GameObject road;
    public GameObject balance;
    public GameObject restart;
    public GameObject metal;
    public GameObject imageLeft;
    public GameObject imageRight;
    public GameObject gridBackground;

    // Check in each frame and depending on whether time is stopped or not, show or hide UI
    void Update()
    {
        
        if (Time.timeScale == 1)
        {
            Grid.SetActive(false);
            playButton.SetActive(false);
            road.SetActive(false);
            balance.SetActive(false);
            metal.SetActive(false);
            restart.SetActive(true);
            gridBackground.SetActive(false);
        }
        else
        {
            Grid.SetActive(true);
            playButton.SetActive(true);
            road.SetActive(true);
            balance.SetActive(true);
            metal.SetActive(true);
            restart.SetActive(false);
            gridBackground.SetActive(true);
        }

    }
}
