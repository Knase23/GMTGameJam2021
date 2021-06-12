using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAwayWhenPlayerIsClose : MonoBehaviour
{

    public bool BlackOutCamera;
    private Color cameraBackgroundBaseColor;

    bool FadeOut;
    public List<Renderer> fadeAwayWithMaterial;
    public List<SpriteRenderer> fadeAwaySprites;

    public List<SpriteRenderer> fadeInSprites;

    float fadeTimer;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player")))
        {
            FadeOut = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.CompareTag("Player")))
        {
            FadeOut = false;
        }
    }

    private void Start()
    {
        cameraBackgroundBaseColor = Camera.main.backgroundColor;
    }

    private void Update()
    {
        if (FadeOut)
        {
            fadeTimer += Time.deltaTime * 2;
        }
        else
        {
            fadeTimer -= Time.deltaTime * 2;
        }
        fadeTimer = fadeTimer > 1 ? 1 : fadeTimer;
        fadeTimer = fadeTimer < 0 ? 0 : fadeTimer;

        if (fadeAwaySprites != null)
        {
            foreach (var item in fadeAwaySprites)
            {
                item.color = new Color(1, 1, 1, 1 - fadeTimer);
            }
        }

        if (fadeInSprites != null)
        {
            foreach (var item in fadeInSprites)
            {
                item.color = new Color(1, 1, 1, fadeTimer);
            }
        }

        if (fadeAwayWithMaterial != null)
        {
            foreach (var item in fadeAwayWithMaterial)
            {
                item.material.color = new Color(1, 1, 1, 1 - fadeTimer);
            }
        }

        if (BlackOutCamera)
        {
            Camera.main.backgroundColor = Color.Lerp(cameraBackgroundBaseColor, Color.black, fadeTimer);
        }
    }
}
