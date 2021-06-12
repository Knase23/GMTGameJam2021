using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// this script moves a character back and forth to simulate movement (lol)

public class WalkingAnimation : MonoBehaviour
{

    private float rotationTimer;
    private float rotationSine;
    private float bobbingTimer;
    private float bobbingSine;

    bool walking;

    public float speed;

    public float rotationAngle;
    public float bobbingHeight;

    public Vector3 localLerpPos;
    public Vector3 prevPos;

    public bool readyForTouch;

    void Update()
    {

        walking = prevPos != transform.position;

        transform.localRotation = Quaternion.identity;
        localLerpPos = Vector3.zero;

        if (walking)
        {
            rotationTimer += Time.deltaTime * speed;
            bobbingTimer += Time.deltaTime;
            bobbingSine = Mathf.Sin(bobbingTimer * speed * 2);
            rotationSine = Mathf.Sin(rotationTimer + 0.5f);
            transform.localRotation = Quaternion.Euler(Vector3.forward * rotationSine * rotationAngle);
            localLerpPos = (Vector3.up * bobbingHeight) * (bobbingSine + 1f);

            if (readyForTouch)
            {
                if (bobbingSine < -0.9f)
                {
                    Debug.Log("touch");
                    readyForTouch = false;
                }
            }
            else
            {
                if (bobbingSine > 0)
                {
                    readyForTouch = true;
                }
            }
        }
        else
        {
            localLerpPos = Vector3.Lerp(localLerpPos, Vector3.zero, Time.deltaTime * 1);
        }

        transform.localPosition = localLerpPos;
        prevPos = this.transform.position;
    }
}
