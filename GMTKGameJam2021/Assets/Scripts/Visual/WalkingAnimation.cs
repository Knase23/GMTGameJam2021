using System.Collections;
using System.Collections.Generic;
using Services;
using UnityEngine;

public enum StepType { None, Player, zero, one, two, three, four, five };
// this script moves a character back and forth to simulate movement (lol)

public class WalkingAnimation : MonoBehaviour
{

    public StepType stepType;

    public Rigidbody rigi;

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

    public ParticleSystem fartDust;

    private void Start()
    {
        rotationTimer = Random.value * 3.14f;
        speed = speed * Random.Range(0.9f, 1.1f);
    }

    void FixedUpdate()
    {
        walking = rigi.velocity != Vector3.zero;
        transform.localRotation = Quaternion.identity;
        localLerpPos = Vector3.zero;

        if (walking)
        {
            rotationTimer += Time.fixedDeltaTime * speed;
            bobbingTimer += Time.fixedDeltaTime;
            bobbingSine = Mathf.Sin(bobbingTimer * speed * 2);
            rotationSine = Mathf.Sin(rotationTimer + 0.5f);
            transform.localRotation = Quaternion.Euler(Vector3.forward * rotationSine * rotationAngle);
            localLerpPos = (Vector3.up * bobbingHeight) * (bobbingSine + 1f);

            if (readyForTouch)
            {
                if (bobbingSine < -0.9f)
                {
                    readyForTouch = false;
                    fartDust.Emit(1);
                    IAudioService audioService = ServiceLocator.GetService<IAudioService>();
                    switch (stepType)
                    {
                        case StepType.None:
                            break;
                        case StepType.Player:
                            audioService.PlaySFX("step_player", this.gameObject);
                            break;
                        case StepType.zero:
                            audioService.PlaySFX("step_00", this.gameObject);
                            break;
                        case StepType.one:
                            audioService.PlaySFX("step_01", this.gameObject);
                            break;
                        case StepType.two:
                            audioService.PlaySFX("step_02", this.gameObject);
                            break;
                        case StepType.three:
                            audioService.PlaySFX("step_03", this.gameObject);
                            break;
                        case StepType.four:
                            audioService.PlaySFX("step_04", this.gameObject);
                            break;
                        case StepType.five:
                            audioService.PlaySFX("step_05", this.gameObject);
                            break;
                    }
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
            localLerpPos = Vector3.Lerp(localLerpPos, Vector3.zero, Time.fixedDeltaTime * 6);
            rotationTimer = 0;
            bobbingTimer = 0;
        }

        transform.localPosition = localLerpPos;
        prevPos = this.transform.position;
    }
}
