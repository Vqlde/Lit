using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTemperature : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float temperature = 0f;

    private SpriteRenderer spriteRenderer;

    private readonly Color warmTone = new Color(1.0f, 0.9f, 0.7f);
    private readonly Color coolTone = new Color(0.0f, 0.0f, 1.0f);

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateTemperature();
    }

    void Update()
    {
        UpdateTemperature();
    }

    void UpdateTemperature()
    {
        if (spriteRenderer != null)
        {
            Color adjustedColor = Color.Lerp(coolTone, warmTone, (temperature + 1f) / 2f);

            spriteRenderer.color = adjustedColor;
        }
    }
}
