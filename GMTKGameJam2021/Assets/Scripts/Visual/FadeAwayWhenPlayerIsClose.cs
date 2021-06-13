using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAwayWhenPlayerIsClose : MonoBehaviour
{

    public bool BlackOutCamera;

    private Renderer ground;

    private Color cameraBackgroundBaseColor;

    public bool fadeOut;
    public static bool fadeGround;
    public static float fadeGroundLerp;
    public List<Renderer> fadeAwayWithMaterial;
    public List<SpriteRenderer> fadeAwaySprites;

    public List<SpriteRenderer> fadeInSprites;

    public float fadeTimer;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player")))
        {
            fadeOut = true;
            fadeGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.CompareTag("Player")))
        {
            fadeOut = false;
            fadeGround = false;
        }
    }

    private void Start()
    {
        cameraBackgroundBaseColor = Camera.main.backgroundColor;
        ground = GameObject.FindWithTag("Ground").GetComponent<Renderer>();
        fadeTimer = 1f;
    }

    private void Update()
    {
        if (fadeOut)
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
                if (item == null) continue;
                item.material.color = new Color(1, 1, 1, 1 - fadeTimer);
            }
        }

        if (BlackOutCamera)
        {
            Camera.main.backgroundColor = Color.Lerp(cameraBackgroundBaseColor, Color.black, fadeTimer);


        }

        fadeGroundLerp += (fadeGround ? 1f : -1f) * Time.deltaTime;
        fadeGroundLerp = fadeGroundLerp > 1 ? 1 : fadeGroundLerp;
        fadeGroundLerp = fadeGroundLerp < 0 ? 0 : fadeGroundLerp;

        ground.material.color = Color.Lerp(Color.white, Color.black, fadeGroundLerp);

    }
}
