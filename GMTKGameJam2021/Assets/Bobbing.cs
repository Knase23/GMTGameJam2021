using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour
{

    private float timer;
    private float sine;
    [SerializeField] private float speed;


    void Update()
    {
        timer += Time.deltaTime * speed;
        sine = (Mathf.Sin(timer) + 1) / 2;
        transform.localPosition = ((Vector3.up * sine) / 2);
    }
}
