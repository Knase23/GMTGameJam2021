using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowersHandler : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Vector3 throwDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            throwDirection.Normalize();
            Follower thrown = first;
            if (thrown)
            {
                first = thrown.behindFollower;
                thrown.thrownBehaviour.GetThrown(throwDirection);
            }
        }
    }

    public Follower first;
    public void AddFollower(Follower follower)
    {
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
