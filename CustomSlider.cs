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
    private Button button;

    void Start()
    {
        // Initialize ui elements.
        ui = GameObject.Find("Canvas");
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        textbox = GameObject.Find("Info").GetComponent<Text>();
        button = GameObject.Find("Button").GetComponent<Button>();
        slider.enabled = true;
        sliderValue = slider.value;
        textbox.text = "10-yr warming: " + sliderValue + " degrees";
        button.onClick.AddListener(Task);
    }

    void Update()
    {
        // Create color gradient based on slider value.
        sliderValue = slider.value;
        Color textColor = new Color(sliderValue / maxSlider, 0.0f, Math.Abs(maxSlider - sliderValue) / maxSlider, 1.0f) ;

        // Apply slider value and color change to textbox UI element.
        textbox.color = textColor;
        textbox.text = "10-yr warming: " + sliderValue + " degrees";

    }

    void Task()
    {
        Application.Quit();
    }
}
