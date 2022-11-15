using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setSoundValue : MonoBehaviour
{
    public Slider mainSlider;
    public AudioSource menuMusic;

    //Set sount volume

    void Start()
    {
        menuMusic.volume = MoneyAndStats.musicVolume;
        mainSlider.value = MoneyAndStats.musicVolume;
    }

    void Update()
    {
        menuMusic.volume = mainSlider.value;
        MoneyAndStats.musicVolume = mainSlider.value;
    }
}
