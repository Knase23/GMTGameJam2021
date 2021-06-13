using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay;
using UnityEngine;

public class SearchForStones : MonoBehaviour
{
    private Follower _follower;
    public Shoot playerShooter;


    public Bullet choosenBullet;

    public float ammotDetectionRange = 20;
    
    bool foundAmmo = false;

    // Start is called before the first frame update
    void Start()
    {
        _follower = GetComponent<Follower>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_follower._handler)
        {
            if (playerShooter == null)
                playerShooter = _follower._handler.GetComponent<Shoot>();

            //Check if the player have enough prepared ammo
            if (playerShooter.HaveEnoughAmmo() == false && choosenBullet == null)
            {
                // If the player have less prepared ammo
                // Find the closest not taken ammo.
                
                float distance = Single.MaxValue;
                foreach (Bullet bullet in Bullet.currentAvailableBullets)
                {
                    if (bullet.enabled && bullet.current == Bullet.State.Collect && bullet.holder == null)
                    {
                        float nDist = Vector3.Distance(transform.position, bullet.transform.position);
                        if (nDist < ammotDetectionRange && nDist < distance)
                        {
                            choosenBullet = bullet;
                            distance = nDist;
                        }
                    }
                }
                
                if (choosenBullet)
                {
                    // Found a bullet to pick up!
                    choosenBullet.holder = transform; // Mark the bullet as taken!
                    playerShooter.prepAmmo++;
                }
            }
            if (choosenBullet)
            {
                _follower.enabled = false;
                _follower.nav.Move(choosenBullet.transform.position);
                
                if (Vector3.Distance(choosenBullet.transform.position, transform.position) < 2)
                {
                    playerShooter.prepAmmo--;
                    playerShooter.CollectBullet(choosenBullet);
                    _follower.enabled = true;
                    choosenBullet = null;
                }
                else if (Vector3.Distance(choosenBullet.transform.position, transform.position) > ammotDetectionRange + 1)
                {
                    choosenBullet.holder = null;
                    choosenBullet = null;
                    _follower.enabled = true;
                    playerShooter.prepAmmo--;

                }
            }
        }

        
        // Go to the ammo
        // Pick Up
        // Go back to Normal
    }
}
