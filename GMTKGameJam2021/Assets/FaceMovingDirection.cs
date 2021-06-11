using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FaceMovingDirection : MonoBehaviour
{
    SpriteRenderer rend;
    public bool baseSpriteIsFacingLeft;

    private float deltaPosX;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (deltaPosX != transform.position.x)
        {
            deltaPosX = transform.position.x;
            if (deltaPosX < 0)
            {
                rend.flipX = baseSpriteIsFacingLeft ? false : true;
            }
            else
            {
                rend.flipX = baseSpriteIsFacingLeft ? true : false;
            }
        }
    }
}
