using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorEffect : MonoBehaviour
{
    public bool onOff = true;
    public float hueSpeed = 50f;
    public float currentHue = 0f;
    public SpriteRenderer spriteRenderer;
    public Color rainbowColor;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (onOff != true)
        {
            //spriteRenderer.color = Color.clear;
            return;
        }
        currentHue += hueSpeed * Time.deltaTime;
        if (currentHue > 360f)
        {
            currentHue -= 360f;
        }
        rainbowColor = Color.HSVToRGB(currentHue / 360f, 1f, 1f);
        spriteRenderer.color = rainbowColor;
    }
}