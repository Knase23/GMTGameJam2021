using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay;
using UnityEngine;

public class AIAttack : MonoBehaviour
{
    public Health target;

    public float minimumAttackDistance = 3f;
    public float timeBetweenAttacks = 1f;
    public float timer = 0;

    public SpriteRenderer rend;
    private void Start()
    {
        timer = timeBetweenAttacks;
        target = Player.Instance.GetComponent<Health>();
    }
    

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist < minimumAttackDistance)
        {

            timer += Time.deltaTime;
            rend.color = Color.Lerp(Color.white, Color.red, timer / timeBetweenAttacks);
            if (timer > timeBetweenAttacks)
            {
                timer = 0;
                target.TakeDamage(1);
            }
        }
        else
        {
            rend.color = Color.white;
        }
    }
}
