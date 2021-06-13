using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay;

public class Dash : MonoBehaviour
{
    public Integer level;
    public Movement movement;
    public WalkingAnimation walkingAnimation;

    float baseMovement;
    float baseAnimationMovement;
    float dashMagnitude;

    bool dashing;

    float dashTimer;

    // Start is called before the first frame update
    void Start()
    {
        baseMovement = movement.speed;
        baseAnimationMovement = walkingAnimation.speed;
        dashMagnitude = 2.25f;
    }

    // Update is called once per frame
    void Update()
    {
        if (level.value < 1) return;
        dashing = (Input.GetKey(KeyCode.LeftShift));

        dashTimer += dashing ? -Time.deltaTime * 1f : Time.deltaTime * 2f;
        dashTimer = dashTimer > 2.5f ? 2.5f : dashTimer;

        if (dashTimer < 0) dashing = false;
        dashTimer = dashTimer < -1f ? -1f : dashTimer;



        movement.speed = dashing ? baseMovement * dashMagnitude : baseMovement;
        walkingAnimation.speed = dashing ? baseAnimationMovement * dashMagnitude : baseAnimationMovement;
    }
}
