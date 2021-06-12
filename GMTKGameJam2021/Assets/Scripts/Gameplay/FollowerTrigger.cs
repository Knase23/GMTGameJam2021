using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerTrigger : MonoBehaviour
{
    public Follower orign;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.name} hit {name}");
        FollowersHandler handler = other.GetComponent<FollowersHandler>();
        if (handler)
        {
            handler.AddFollower(orign);
            gameObject.SetActive(false);
        }
        
    }
}
