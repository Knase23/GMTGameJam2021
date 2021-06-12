using System;
using System.Collections;
using System.Collections.Generic;
using Services;
using UnityEngine;

public class FollowersHandler : MonoBehaviour
{
    public int amountOfFollowers;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Vector3 throwDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            throwDirection.Normalize();
            Follower thrown = first;
            if (thrown)
            {
                amountOfFollowers--;
                ServiceLocator.GetService<IAudioService>().SetRTPC("followers",amountOfFollowers);
                first = thrown.behindFollower;
                thrown.thrownBehaviour.GetThrown(throwDirection);
                
            }
        }
    }

    public Follower first;
    public void AddFollower(Follower follower)
    {
        amountOfFollowers++;
        ServiceLocator.GetService<IAudioService>().SetRTPC("followers",amountOfFollowers);
        
        ServiceLocator.GetService<IAudioService>().PlaySFX("follower_pickup");
        enabled = true;
        follower._handler = this;
        if (first)
        {
            first.AddFollower(follower,this);
        }
        else
        {
            first = follower;
        }
    }
}
