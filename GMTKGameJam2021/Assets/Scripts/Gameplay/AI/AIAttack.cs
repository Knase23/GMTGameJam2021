using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay;
using Services;
using UnityEngine;

public class AIAttack : MonoBehaviour
{
    public Health target;

    public float minimumAttackDistance = 3f;
    public float timeBetweenAttacks = 1f;
    public float timer = 0;

    Sprite defaultSprite;
    public Sprite angrySprite;
    public SpriteRenderer rend;

    private void Start()
    {
        timer = timeBetweenAttacks;
        target = Player.Instance.GetComponent<Health>();
        defaultSprite = rend.sprite;
    }


    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist < minimumAttackDistance)
        {
            timer += Time.deltaTime;
            //rend.color = Color.Lerp(Color.white, Color.red, timer / timeBetweenAttacks);

            if (timer / timeBetweenAttacks > 0.8f)
            {
                rend.sprite = angrySprite;
            }
            else
            {
                rend.sprite = defaultSprite;
            }

            if (timer > timeBetweenAttacks)
            {
                timer = 0;
                target.TakeDamage(1);
                ServiceLocator.GetService<IAudioService>().PlaySFX("ogre_attack");
            }
        }
        else
        {
            //rend.color = Color.white;
            rend.sprite = defaultSprite;
        }
    }
}