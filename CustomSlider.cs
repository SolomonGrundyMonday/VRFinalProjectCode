using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomSlider : MonoBehaviour
{
    // Private member variables for UI/interactivity elements.
    private Slider slider;
    private float sliderValue;
    private const float maxSlider = 3.0f;
    private Text textbox;
    private GameObject ui;
    public ParticleSystem fireEffect;
    public ParticleSystem smokeEffect;

    void Start()
    {
        // Initialize ui elements.
        ui = GameObject.Find("Canvas");
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        textbox = GameObject.Find("Info").GetComponent<Text>();
        slider.enabled = true;
        sliderValue = slider.value;
        textbox.text = "Warming over 10 years: " + sliderValue + " degrees";
    }

    void Update()
    {
        // If the player depresses the alpha 1 key, decrease slider value.
        if (Input.GetKeyDown(KeyCode.Alpha1) && sliderValue > 0.0f)
        {
            sliderValue -= 0.1f;
            sliderValue = (sliderValue < 0.0f) ? 0.0f : sliderValue;
        }
        // If the player depresses the alpha 2 key, increase slider value.
        else if (Input.GetKeyDown(KeyCode.Alpha2) && sliderValue < 3.0f)
        {
            sliderValue += 0.1f;
            sliderValue = (sliderValue > 3.0f) ? 3.0f : sliderValue;
        }
        else if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        // Create color gradient based on slider value.
        slider.value = sliderValue;
        Color textColor = new Color(sliderValue / maxSlider, 0.0f, Math.Abs(maxSlider - sliderValue) / maxSlider, 1.0f);

        // Apply slider value and color change to textbox UI element.
        textbox.color = textColor;
        textbox.text = "Warming over 10 years: " + sliderValue + " degrees";

        // Disable emissions for particle system if the slider value drops below 1 degree of warming
        if (sliderValue < 1.0f)
        {
            fireEffect.enableEmission = false;
            smokeEffect.enableEmission = false;
        }
        // Otherwise enable emissions.
        else
        {
            fireEffect.enableEmission = true;
            smokeEffect.enableEmission = true;
        }

        // Higher max particles proportional to the slider value.
        var fireEffectMain = fireEffect.main;
        fireEffectMain.maxParticles = (int)sliderValue * 100;

        // Higher max particles proportional to the slider value.
        var smokeEffectMain = smokeEffect.main;
        smokeEffectMain.maxParticles = (int)sliderValue * 100;
    }

}
