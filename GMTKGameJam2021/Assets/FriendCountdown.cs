using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendCountdown : MonoBehaviour
{
    public List<Sprite> numbers;
    SpriteRenderer rend;

    void Start()
    {
        FollowersHandler handler = FindObjectOfType<FollowersHandler>();
        handler.OnAmountOfFollowersUpdate.AddListener(UpdateNumber);
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = numbers[0];
    }

    public void UpdateNumber(int val)
    {
        rend.sprite = numbers[val];
    }
}
