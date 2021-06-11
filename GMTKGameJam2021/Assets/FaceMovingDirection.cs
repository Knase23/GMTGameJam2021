using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FaceMovingDirection : MonoBehaviour
{
    SpriteRenderer rend;
    public bool baseSpriteIsFacingLeft;

    public float deltaPosX;
    public float prevPosX;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        deltaPosX = transform.position.x - prevPosX;


        if (Mathf.Abs(deltaPosX) < 0.05f)
        {
            // do nothing
        }
        else if (deltaPosX != 0)
        {
            if (deltaPosX > 0)
            {
                rend.flipX = baseSpriteIsFacingLeft ? false : true;
            }
            else
            {
                rend.flipX = baseSpriteIsFacingLeft ? true : false;
            }
        }

        prevPosX = transform.position.x;
    }
}
