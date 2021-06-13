using System;
using System.Collections;
using System.Collections.Generic;
using Services;
using UnityEngine;
using UnityEngine.Events;

public class FollowersHandler : MonoBehaviour
{
    public int amountOfFollowers;
    public UnityEvent<int> OnAmountOfFollowersUpdate;
    private bool perform;
    private void Update()
    {
        
        if (Input.GetAxis("Fire2") > 0)
        {
            if (!perform)
            {
                Vector3 throwDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                throwDirection.Normalize();
                Follower thrown = first;
                if (thrown)
                {
                    amountOfFollowers--;
                    OnAmountOfFollowersUpdate?.Invoke(amountOfFollowers);
                    ServiceLocator.GetService<IAudioService>().SetRTPC("followers",amountOfFollowers);
                    first = thrown.behindFollower;
                    thrown.thrownBehaviour.GetThrown(throwDirection);
                
                }
                perform = true;
            }
        }
        else
        {
            perform = false;
        }
    }

    public Follower first;
    public void AddFollower(Follower follower)
    {
        amountOfFollowers++;
        OnAmountOfFollowersUpdate?.Invoke(amountOfFollowers);
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
