using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public FollowersHandler _handler;
    private AINavigation nav;

    public Follower frontFollower;
    public Follower behindFollower;
    public FollowerTrigger trigger;
    public ThrownBehaviour thrownBehaviour;
    public float minimumDistance = 1;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<AINavigation>();
        thrownBehaviour = GetComponent<ThrownBehaviour>();
        thrownBehaviour.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_handler == null) return;

        if (frontFollower == null)
        {
            if (Vector3.Distance(_handler.transform.position, transform.position) < minimumDistance)
            {
                nav.inputDirection = Vector3.zero;
            }
            else
            {
                nav.inputDirection = _handler.transform.position - transform.position;
            }
        }
        else
        {
            if (Vector3.Distance(frontFollower.transform.position, transform.position) < minimumDistance)
            {
                nav.inputDirection = Vector3.zero;
            }
            else
            {
                nav.inputDirection = frontFollower.transform.position - transform.position;
            }
        }
    }
    public void RemoveFollower()
    {
        if(behindFollower)
            behindFollower.frontFollower = frontFollower ? frontFollower : null;
        
        if(frontFollower)
            frontFollower.behindFollower = behindFollower ? behindFollower : null;

        behindFollower = null;
        frontFollower = null;
        _handler = null;
        
    }
    public void ActivateTrigger()
    {
        trigger.gameObject.SetActive(true);
    }
    public void AddFollower(Follower follower, FollowersHandler handler)
    {
        _handler = handler;
        if (behindFollower)
        {
            behindFollower.AddFollower(follower, handler);
        }
        else
        {
            behindFollower = follower;
            follower.frontFollower = this;
        }
    }
}