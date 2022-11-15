using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class setResolution : MonoBehaviour
{
    public Toggle fullscreenTog;

    public Text getResolutionText;

    string resolutionText;
    string horizontalRes;
    string verticalRes;

    // Class responsible for change window resolution

    void Start()
    {
        resolutionText = getResolutionText.text;
        horizontalRes = resolutionText.Substring(0, 4);
        verticalRes = resolutionText.Substring(7, resolutionText.Length - 7);
        Screen.SetResolution(Int32.Parse(horizontalRes), Int32.Parse(verticalRes), fullscreenTog.isOn);
        fullscreenTog.isOn = Screen.fullScreen;
    }

    
    public void updateResolution()
    {
        resolutionText = getResolutionText.text;
        horizontalRes = resolutionText.Substring(0, 4);
        verticalRes = resolutionText.Substring(7, resolutionText.Length-7);
        Screen.SetResolution(Int32.Parse(horizontalRes), Int32.Parse(verticalRes), fullscreenTog.isOn);
    }
    

    public void setFullscreen()
    {
        Screen.fullScreen = fullscreenTog.isOn;
    }

    [System.Serializable]
    public class ResolutionItem
    {
        public int horizontal;
        public int vertical;
    }
}
