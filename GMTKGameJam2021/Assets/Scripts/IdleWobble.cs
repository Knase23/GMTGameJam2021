using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleWobble : MonoBehaviour
{
    float idleTimer;
    bool idling;
    Vector3 startScale;

    float sineTimer;
    float sine;
    float wobblemagnitude;
    float sineSpeed;

    // Start is called before the first frame update
    void Start()
    {
        wobblemagnitude = 0.20f;
        sineSpeed = 8.5f;
        idling = true;
        sineTimer = Random.value * 3.14f;
        startScale = this.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // idleTimer += Time.deltaTime;
        //
        // if (idleTimer > 1.5f)
        // {
        //     idling = true;
        // }

        if (idling)
        {
            sineTimer += Time.deltaTime * sineSpeed;
            sine = Mathf.Sin((sineTimer) + 1) / 2;
            sine += 0.5f;
            transform.localScale = startScale + (Vector3.up * wobblemagnitude * sine);
        }
    }
}
