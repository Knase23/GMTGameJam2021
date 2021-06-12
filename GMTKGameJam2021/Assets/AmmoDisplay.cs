using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDisplay : MonoBehaviour
{
    public float idleTimer;
    private bool displayMe;
    private Color viewColor;

    public Integer current;
    public Integer maxAmmo;

    private int lastKnownCurrent;
    private int lastKnownMaximum;

    public Sprite zero_three;
    public Sprite one_three;
    public Sprite two_three;
    public Sprite three_three;

    public Sprite zero_two;
    public Sprite one_two;
    public Sprite two_two;

    public Sprite zero_one;
    public Sprite one_one;

    public SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        UpdateAmmoSprite();
    }

    private void UpdateAmmoSprite()
    {
        switch (maxAmmo.value)
        {
            case 1:
                switch (current)
                {
                    case 0:
                        rend.sprite = zero_one;
                        break;
                    case 1:
                        rend.sprite = one_one;
                        break;

                    default:
                        break;
                }
                break;

            case 2:

                switch (current)
                {
                    case 0:
                        rend.sprite = zero_two;
                        break;
                    case 1:
                        rend.sprite = one_two;
                        break;
                    case 2:
                        rend.sprite = two_two;
                        break;
                    default:
                        break;
                }
                break;

            case 3:
                switch (current)
                {
                    case 0:
                        rend.sprite = zero_three;
                        break;
                    case 1:
                        rend.sprite = one_three;
                        break;
                    case 2:
                        rend.sprite = two_three;
                        break;
                    case 3:
                        rend.sprite = three_three;
                        break;

                    default:
                        break;
                }
                break;
            default:
                Debug.Log("we dont have graphics for this amount of max ammo (we could repeat the ones we have maybe)");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lastKnownCurrent != current.value || lastKnownMaximum != maxAmmo.value)
        {
            lastKnownCurrent = current;
            lastKnownMaximum = maxAmmo;
            idleTimer = 2.5f;
            UpdateAmmoSprite();
            LeanTween.scale(this.gameObject, Vector3.one * 1.20f, 0.35f).setEase(LeanTweenType.punch);
        }

        idleTimer -= Time.deltaTime;
        displayMe = idleTimer > 0;

        viewColor = displayMe ? Color.white : Color.clear;
        rend.color = Color.Lerp(rend.color, viewColor, Time.deltaTime * 6.5f);
    }
}
