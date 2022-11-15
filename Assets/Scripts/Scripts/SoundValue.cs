using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundValue : MonoBehaviour
{
    public Slider mainSlider;
    public AudioSource barSound;
    public AudioSource metalSound;
    public AudioSource gameMusic;

    //Change the sound value in the menu using the slider

    void Start()
    {
        mainSlider.value = MoneyAndStats.musicVolume;
        barSound.volume = MoneyAndStats.musicVolume;
        metalSound.volume = MoneyAndStats.musicVolume;
        gameMusic.volume = MoneyAndStats.musicVolume;
        
    }

    void Update()
    {
        barSound.volume = mainSlider.value;
        metalSound.volume = mainSlider.value;
        gameMusic.volume = mainSlider.value;
        MoneyAndStats.musicVolume = mainSlider.value;
    }
}
