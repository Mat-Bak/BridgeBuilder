using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class TriggerLost : MonoBehaviour
{
    public GameObject destroyMenu;

    //Trigger is activated when car is in the box colision
    // Then show menu where user can restart game or back to main menu

    public void OnTriggerEnter(Collider other)
    {
        destroyMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
