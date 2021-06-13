using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinBuildingOpen : MonoBehaviour
{

    public Integer floorLevel;
    public float yRotation;
    public GameObject rotator;
    public List<MeshCollider> colliders;

    public bool condition_one;
    public bool condition_two;

    public BoxCollider entryWayCollider;

    void Start()
    {

    }

    void Update()
    {
        yRotation = rotator.transform.rotation.y;

        condition_one = floorLevel == 1;
        condition_two = (yRotation > -0.1f && yRotation < 0.1f);

        foreach (var item in colliders)
        {
            item.enabled = condition_one && condition_two;
            item.enabled = !item.enabled;
        }

        entryWayCollider.enabled = condition_one && condition_two;
    }
}
