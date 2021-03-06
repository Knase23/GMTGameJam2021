using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay;
using Services;
using UnityEngine;

public class ThrownBehaviour : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 10;
    private Rigidbody rigi;
    private AINavigation nav;
    private Follower Follower;

    public Transform billboardCharacter;
    public bool hitSomething;

    public float timeInAir = 0.55f;
    public float timer;
    public float maxJumpHeight = 5;

    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        nav = GetComponent<AINavigation>();
        Follower = GetComponent<Follower>();
    }

    public void GetThrown(Vector3 dir)
    {
        ServiceLocator.GetService<IAudioService>().PlaySFX("follower_throw");
        nav.enabled = false;
        enabled = true;
        hitSomething = false;
        this.direction = dir;
        rigi.velocity = direction * speed;
        transform.position = Follower._handler.transform.position;
        Follower.RemoveFollower();
        timer = 0;
    }

    private void Update()
    {
        if (timer < timeInAir && hitSomething == false)
        {
            gameObject.layer = 7;
            //Fly up
            timer += Time.deltaTime;

            if (timer > timeInAir)
                timer = timeInAir;

            float percentHalf = timer / (timeInAir * 0.5f);

            if (percentHalf > 1)
            {
                float remover = percentHalf - 1;
                percentHalf -= remover * 2;
            }
            Vector3 pos = billboardCharacter.position;
            pos.y = percentHalf * maxJumpHeight;
            billboardCharacter.position = pos;
        }
        else
        {
            ThrownDone();
        }
    }
    public void ThrownDone()
    {
        Vector3 pos = billboardCharacter.position;
        pos.y = 0;
        billboardCharacter.position = pos;
        gameObject.layer = 8;
        Follower.ActivateTrigger();
        rigi.velocity = Vector3.zero;
        nav.enabled = true;
        nav.Pause();
        enabled = false;
        ServiceLocator.GetService<IAudioService>().PlaySFX("follower_throw_Impact");
    }
    public void OnCollisionEnter(Collision other)
    {
        if (enabled == false) return;
        Debug.Log("Hit:" + other.gameObject.name, this);

        if (other.gameObject.layer == 9)
        {
            other.gameObject.GetComponent<Health>().TakeDamage(1);
        }
        
        hitSomething = true;
        ThrownDone();
    }
}