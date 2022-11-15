using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipMove : MonoBehaviour
{
    public GameObject ship;
    private Vector3 shipPosition;
    private Vector3 newPosition;
    public GameObject carEasy;
    public GameObject carMedium;
    public GameObject carHard;

    // Set car dependent to level and show ship if game level is equal "Hard"

    void Start()
    {
        
        shipPosition = ship.transform.position;
        if (MoneyAndStats.level == "HARD")
        {
            ship.SetActive(true);
            carEasy.SetActive(false);
            carMedium.SetActive(false);
            carHard.SetActive(true);
        }
        else if (MoneyAndStats.level == "MEDIUM")
        {
            ship.SetActive(false);
            carEasy.SetActive(false);
            carMedium.SetActive(true);
            carHard.SetActive(false);
        }
        else if(MoneyAndStats.level == "EASY")
        {
            ship.SetActive(false);
            carEasy.SetActive(true);
            carMedium.SetActive(false);
            carHard.SetActive(false);
        }
    }

    void Update()
    {
        if(MoneyAndStats.level == "HARD" && Time.timeScale==1 && shipPosition.z > -20)
        {
            shipPosition.z -= Time.unscaledDeltaTime;
            newPosition = new Vector3(shipPosition.x, shipPosition.y, shipPosition.z);
            ship.transform.position = newPosition;
        }

    }
}
