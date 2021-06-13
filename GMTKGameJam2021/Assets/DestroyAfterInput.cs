using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyAfterInput : MonoBehaviour
{
    public bool activated;
    public Image img;
    public Integer level;

    void Start()
    {
        img.color = Color.clear;
    }

    void Update()
    {
        if (level > 0 && !activated)
        {
            ShowMe();
            activated = true;
        }

        if (!activated) return;
    }

    public void ShowMe()
    {
        LeanTween.scale(gameObject, Vector3.one * 1.2f, 0.35f).setEase(LeanTweenType.punch);
        img.color = Color.white;
    }
}
