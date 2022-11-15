using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMaretial : MonoBehaviour
{
    public BarCreator barCreator;
    public Button roadButton;
    public Button metalButton;
    public Button deleteButton;
    public GameObject roadPrice;
    public GameObject metalPrice;
    private Color startColor = new Color((float)0.08, (float)1, (float)1);
    private Color clickedColor = new Color((float)1, (float)0.6, (float)0.08); 

    //Change material between road and metal


    // On start set objects cost, and button color
    void Start()
    {

        barCreator.price = MoneyAndStats.roadCost;
        barCreator.RoadInstance = barCreator.Road;
        Bar.enableDelete = false;
        BarCreator.BuildMode = true;
        roadButton.GetComponent<Image>().color = clickedColor;
        metalButton.GetComponent<Image>().color = startColor;
        deleteButton.GetComponent<Image>().color = startColor;
        roadPrice.GetComponent<Image>().color = clickedColor;
        metalPrice.GetComponent<Image>().color = startColor;
        


    }
    

    // Change mode between create road, metal or delete objects
    public void SelectMaterial(int material)
    {
        if(material == 0)
        {
            barCreator.price = MoneyAndStats.roadCost;
            barCreator.RoadInstance = barCreator.Road;
            Bar.enableDelete = false;
            BarCreator.BuildMode = true;
            roadButton.GetComponent<Image>().color = clickedColor;
            metalButton.GetComponent<Image>().color = startColor;
            deleteButton.GetComponent<Image>().color = startColor;
            roadPrice.GetComponent<Image>().color = clickedColor;
            metalPrice.GetComponent<Image>().color = startColor;
        }
        else if (material == 1)
        {
            barCreator.price = MoneyAndStats.metalCost;
            barCreator.RoadInstance = barCreator.Beam;
            Bar.enableDelete = false;
            BarCreator.BuildMode = true;
            roadButton.GetComponent<Image>().color = startColor;
            metalButton.GetComponent<Image>().color = clickedColor;
            deleteButton.GetComponent<Image>().color = startColor;
            roadPrice.GetComponent<Image>().color = startColor;
            metalPrice.GetComponent<Image>().color = clickedColor;
        }
        else
        {
            Bar.enableDelete = true;
            roadButton.GetComponent<Image>().color = startColor;
            metalButton.GetComponent<Image>().color = startColor;
            deleteButton.GetComponent<Image>().color = clickedColor;
            roadPrice.GetComponent<Image>().color = startColor;
            metalPrice.GetComponent<Image>().color = startColor;
        }
    }
    
    public void EnableDisableDelete()
    {
        BarCreator.BuildMode = false;
        Bar.enableDelete = true;
    }
}
