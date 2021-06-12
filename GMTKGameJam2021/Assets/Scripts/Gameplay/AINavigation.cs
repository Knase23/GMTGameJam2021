using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AINavigation : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public int speed;

    public Vector3 inputDirection;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputDirection.Normalize();
        Vector3 velocity = new Vector3(inputDirection.x, 0, inputDirection.z);
        _rigidbody.velocity = velocity * speed;
    }
}
