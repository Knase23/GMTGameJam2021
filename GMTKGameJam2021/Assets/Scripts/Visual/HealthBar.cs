using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Note: health is represented in increments of 0.5. Meaning that 2 health is the same as 2 halves of 1 whole heart container

public class HealthBar : MonoBehaviour
{

    public Sprite container_full;
    public Sprite container_half;
    public Sprite container_empty;
    public Sprite container_invisible;
    public Integer health;

    public List<Image> healthContainers;

    public int maxHealth;
    public int deltaHealth;

    void Start()
    {
        maxHealth = int.MinValue;
        deltaHealth = int.MinValue;
    }

    void Update()
    {
        if (deltaHealth != health.value)
        {
            deltaHealth = health.value;
            SetSpritesToRepresentHealth();
        }

        if (maxHealth < deltaHealth)
        {
            maxHealth = deltaHealth;
        }

#if UNITY_EDITOR

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            health.value = health.value - 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            health.value = health.value + 1;
        }

#endif
    }

    private void SetSpritesToRepresentHealth()
    {
        foreach (var item in healthContainers)
        {
            item.sprite = container_invisible;
        }

        for (int i = 0; i < (maxHealth / 2) + 1; i++)
        {
            healthContainers[i].sprite = container_empty;
        }

        int healthPool = deltaHealth;

        for (int i = 0; i < 100; i++) // arbitrary large number...
        {
            if (healthPool > 1)
            {
                healthContainers[i].sprite = container_full;
                healthPool -= 2;
                continue;
            }
            else if (healthPool == 1)
            {
                healthContainers[i].sprite = container_half;
                healthPool -= 1;
                continue;
            }
            else
            {
                break;
            }
        }
    }
}
