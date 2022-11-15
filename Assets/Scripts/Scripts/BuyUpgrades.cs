using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class BuyUpgrades : MonoBehaviour
{
    public Text getMoney;
    public Sprite EnableButtom;
    public Sprite DisableButton;
    public Button firstMoneyButton;
    public Button secondMoneyButton;
    public Button thirdMoneyButton;

    public Button firstRoadButton;
    public Button secondRoadButton;
    public Button thirdRoadButton;

    public Button firstMetalButton;
    public Button secondMetalButton;
    public Button thirdMetalButton;
    public static int money;
    public static int addMoney;

    public static int fristUpdate=0;
    public static int secondUpdate=0;
    public static int thirdUpdate= 0;

    // Update manager. It allows you to buy them and gives you access to new ones


    //On start set balace 
    void Start()
    {
        money = MoneyAndStats.coinsBalance;
        getMoney.text = money.ToString();

    }

    // On Awake check to which updates user get access and which are blocked yet 
    void Awake()
    {
        secondMoneyButton.interactable = false;
        thirdMoneyButton.interactable = false;
        secondRoadButton.interactable = false;
        thirdRoadButton.interactable = false;
        secondMetalButton.interactable = false;
        thirdMetalButton.interactable = false;
        
        switch (fristUpdate)
        {
            case 1:
                firstMoneyButton.image.sprite = EnableButtom;
                secondMoneyButton.interactable = true;
                break;
            case 2:
                firstMoneyButton.image.sprite = EnableButtom;
                secondMoneyButton.interactable = true;
                secondMoneyButton.image.sprite = EnableButtom;
                thirdMoneyButton.interactable = true;
                break;
            case 3:
                firstMoneyButton.image.sprite = EnableButtom;
                secondMoneyButton.interactable = true;
                secondMoneyButton.image.sprite = EnableButtom;
                thirdMoneyButton.interactable = true;
                thirdMoneyButton.image.sprite = EnableButtom;
                break;
        }

        switch (secondUpdate)
        {
            case 1:
                firstRoadButton.image.sprite = EnableButtom;
                secondRoadButton.interactable = true;
                break;
            case 2:
                firstRoadButton.image.sprite = EnableButtom;
                secondRoadButton.interactable = true;
                secondRoadButton.image.sprite = EnableButtom;
                thirdRoadButton.interactable = true;
                break;
            case 3:
                firstRoadButton.image.sprite = EnableButtom;
                secondRoadButton.interactable = true;
                secondRoadButton.image.sprite = EnableButtom;
                thirdRoadButton.interactable = true;
                thirdRoadButton.image.sprite = EnableButtom;
                break;
        }

        switch (thirdUpdate)
        {
            case 1:
                firstMetalButton.image.sprite = EnableButtom;
                secondMetalButton.interactable = true;
                break;
            case 2:
                firstMetalButton.image.sprite = EnableButtom;
                secondMetalButton.interactable = true;
                secondMetalButton.image.sprite = EnableButtom;
                thirdMetalButton.interactable = true;
                break;
            case 3:
                firstMetalButton.image.sprite = EnableButtom;
                secondMetalButton.interactable = true;
                secondMetalButton.image.sprite = EnableButtom;
                thirdMetalButton.interactable = true;
                thirdMetalButton.image.sprite = EnableButtom;
                break;
        }
    }

    // Methods responsible for checking which updates user have, which can get and which is not access yet

    //First level with money updates 
    public void buyFirstMoneyUpgrade()
    {
        if (MoneyAndStats.coinsBalance >= 5 && firstMoneyButton.image.sprite == DisableButton)
        {
            MoneyAndStats.coinsBalance -= 5;
            firstMoneyButton.image.sprite = EnableButtom;
            secondMoneyButton.interactable = true;
            getMoney.text = MoneyAndStats.coinsBalance.ToString();
            MoneyAndStats.balance += 100;
            fristUpdate = 1;
        }
    }

    //Second level with money update
    public void buySecondMoneyUpgrade()
    {
        if (MoneyAndStats.coinsBalance >= 10 && secondMoneyButton.image.sprite == DisableButton)
        {
            MoneyAndStats.coinsBalance -= 10;
            secondMoneyButton.image.sprite = EnableButtom;
            thirdMoneyButton.interactable = true;
            getMoney.text = MoneyAndStats.coinsBalance.ToString();
            MoneyAndStats.balance += 200;
            fristUpdate = 2;
        }
    }

    //Third level with money update
    public void buyThirdMoneyUpgrade()
    {
        if (MoneyAndStats.coinsBalance >= 15 && thirdMoneyButton.image.sprite == DisableButton)
        {
            MoneyAndStats.coinsBalance -= 15;
            thirdMoneyButton.image.sprite = EnableButtom;
            getMoney.text = MoneyAndStats.coinsBalance.ToString();
            MoneyAndStats.balance += 300;
            fristUpdate = 3;
        }
    }


    //First level with road updates 
    public void buyFirstRoadUpgrade()
    {
        if (MoneyAndStats.coinsBalance >= 5 && firstRoadButton.image.sprite == DisableButton)
        {
            MoneyAndStats.coinsBalance -= 5;
            firstRoadButton.image.sprite = EnableButtom;
            secondRoadButton.interactable = true;
            getMoney.text = MoneyAndStats.coinsBalance.ToString();
            MoneyAndStats.roadCost -= 5;
            secondUpdate = 1;
        }
    }

    //Second level with road updates 
    public void buySecondRoadUpgrade()
    {
        if (MoneyAndStats.coinsBalance >= 10 && secondRoadButton.image.sprite == DisableButton)
        {
            MoneyAndStats.coinsBalance -= 10;
            secondRoadButton.image.sprite = EnableButtom;
            thirdRoadButton.interactable = true;
            getMoney.text = MoneyAndStats.coinsBalance.ToString();
            MoneyAndStats.roadCost -= 10;
            secondUpdate = 2;
        }
    }

    //Third level with road updates 
    public void buyThirdRoadUpgrade()
    {
        if (MoneyAndStats.coinsBalance >= 15 && thirdRoadButton.image.sprite == DisableButton)
        {
            MoneyAndStats.coinsBalance -= 15;
            thirdRoadButton.image.sprite = EnableButtom;
            getMoney.text = MoneyAndStats.coinsBalance.ToString();
            MoneyAndStats.roadCost -= 15;
            secondUpdate = 3;
        }
    }


    //First level with metal updates 
    public void buyFirstMetalpgrade()
    {
        if (MoneyAndStats.coinsBalance >= 5 && firstMetalButton.image.sprite == DisableButton)
        {
            MoneyAndStats.coinsBalance -= 5;
            firstMetalButton.image.sprite = EnableButtom;
            secondMetalButton.interactable = true;
            getMoney.text = MoneyAndStats.coinsBalance.ToString();
            MoneyAndStats.metalCost -= 10;
            thirdUpdate = 1;
        }
    }

    //Second level with metal updates 
    public void buySecondMetalUpgrade()
    {
        if (MoneyAndStats.coinsBalance >= 10 && secondMetalButton.image.sprite == DisableButton)
        {
            MoneyAndStats.coinsBalance -= 10;
            secondMetalButton.image.sprite = EnableButtom;
            thirdMetalButton.interactable = true;
            getMoney.text = MoneyAndStats.coinsBalance.ToString();
            MoneyAndStats.metalCost -= 15;
            thirdUpdate = 2;
        }
    }

    //Third level with metal updates 
    public void buyThirdMetalUpgrade()
    {
        if (MoneyAndStats.coinsBalance >= 15 && thirdMetalButton.image.sprite == DisableButton)
        {
            MoneyAndStats.coinsBalance -= 15;
            thirdMetalButton.image.sprite = EnableButtom;
            getMoney.text = MoneyAndStats.coinsBalance.ToString();
            MoneyAndStats.metalCost -= 20;
            thirdUpdate = 3;
        }
    }

}
