using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{

    public Integer exp;
    public Integer maxExp;
    private int lastKnownValue;
    private int lastKnownMaxValue;

    public List<Image> experienceBarSegments;

    public Sprite leftEmpty;
    public Sprite leftFilled;

    public Sprite middleEmpty;
    public Sprite middleFilled;

    public Sprite rightEmpty;
    public Sprite rightFilled;

    public Sprite invisible;

    void Start()
    {
        UpdateExperienceBar();
    }

    void Update()
    {
        if (lastKnownValue != exp.value || lastKnownMaxValue != maxExp.value)
        {
            lastKnownValue = exp.value;
            lastKnownMaxValue = maxExp.value;
            UpdateExperienceBar();
        }

    }

    private void UpdateExperienceBar()
    {
        foreach (var item in experienceBarSegments) // hide all
        {
            item.sprite = invisible;
        }
        int xpPool = exp.value;
        for (int i = 0; i < maxExp.value; i++)
        {
            Sprite empty = middleEmpty;
            Sprite filled = middleFilled;
            if (i == 0)
            {
                empty = leftEmpty;
                filled = leftFilled;
            }
            else if (i == maxExp.value - 1)
            {
                empty = rightEmpty;
                filled = rightFilled;
            }

            if (xpPool > 0)
            {
                experienceBarSegments[i].sprite = filled;
                xpPool--;
            }
            else
            {
                experienceBarSegments[i].sprite = empty;
            }
        }

    }
}
