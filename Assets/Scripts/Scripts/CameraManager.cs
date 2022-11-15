using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject CamBuild;
    public GameObject CamEasy;
    public GameObject CamBridge;
    public GameObject CamHard;
    public GameObject CamMedium;


    // Set camera depending on selected game level
    void Update()
    {
        
        if (Time.timeScale == 1 && MoneyAndStats.level == "HARD")
        {
            CamBuild.SetActive(false);
            CamEasy.SetActive(false);
            CamHard.SetActive(true);
            CamMedium.SetActive(false);
            CamBridge.SetActive(true);
        }
        else if (Time.timeScale == 1 && MoneyAndStats.level == "EASY")
        {
            CamBuild.SetActive(false);
            CamEasy.SetActive(true);
            CamHard.SetActive(false);
            CamMedium.SetActive(false);
            CamBridge.SetActive(true);
        }
        else if(Time.timeScale == 1 && MoneyAndStats.level == "MEDIUM")
        {
            CamBuild.SetActive(false);
            CamEasy.SetActive(false);
            CamHard.SetActive(false);
            CamMedium.SetActive(true);
            CamBridge.SetActive(true);
        }
        else
        {
            CamBuild.SetActive(true);
            CamEasy.SetActive(false);
            CamHard.SetActive(false);
            CamMedium.SetActive(false);
            CamBridge.SetActive(false);
        }
    }
}
