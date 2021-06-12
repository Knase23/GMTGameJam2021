using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Camera cam;

    private void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }

        transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward,
        cam.transform.rotation * Vector3.up);

    }
    void FixedUpdate()
    {

        //transform.rotation = cam

        //transform.LookAt(cam.transform.position, Vector3.up);
    }
}
