using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPrintFade : MonoBehaviour
{
    private SpriteRenderer sprite = null;
    private float fadeTime = 1.5f;
    private float timer = 0.0f;
    private float normalizedTime = 0.0f;
    private Color targetColor;
    private Color originalColor;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        targetColor = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.0f);
        originalColor = sprite.color;
    }

    private void Update()
    {
        if (timer < fadeTime)
        {
            timer += Time.deltaTime;
            normalizedTime = timer / fadeTime;
            sprite.color = Color.Lerp(originalColor, targetColor, normalizedTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
