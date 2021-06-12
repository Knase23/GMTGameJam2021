using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FartDust : MonoBehaviour
{
    public ParticleSystem sys;
    public float deltaPosX;
    public float prevPosX;

    private float timer;
    public float timerReset;
    public int emitAmount;

    void Update()
    {
        deltaPosX = transform.position.x - prevPosX;

        if (Mathf.Abs(deltaPosX) < 0.05f)
        {
            // do nothing
        }
        else if (deltaPosX != 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                sys.Emit(emitAmount);
                timer = timerReset * Random.Range(0.75f, 1.25f);
            }
        }

        prevPosX = transform.position.x;
    }
}
