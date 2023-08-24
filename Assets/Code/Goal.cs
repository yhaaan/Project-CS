using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public float hueSpeed = 50f;
    public float currentHue = 0f;
    public SpriteRenderer paper;
    public Color rainbowColor;


    private void Awake()
    {
        paper = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        currentHue += hueSpeed * Time.deltaTime;
        if(currentHue > 360f)
        {
            currentHue -= 360f;
        }
        rainbowColor = Color.HSVToRGB(currentHue / 360f, 1f, 1f);
        paper.color = rainbowColor;
    }
}
