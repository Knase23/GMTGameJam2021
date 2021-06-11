using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Camera Camera;
    void LateUpdate()
    {
        transform.LookAt(Camera.transform.position, Vector3.up);
    }
}
