using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetatchOnPlayerCollision : MonoBehaviour
{
    public GameObject detatchingObject;
    public IdleWobble wobble;

    private void Start()
    {
        wobble.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (detatchingObject.transform.parent == null) return;
        
        detatchingObject.transform.SetParent(null, true);
        wobble.enabled = true;
        
        Destroy(this.gameObject);
    }
}
