using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetatchOnPlayerCollision : MonoBehaviour
{
    public GameObject detatchingObject;

    public IdleWobble wobble;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (detatchingObject.transform.parent != null)
        {
            detatchingObject.transform.SetParent(null, true);
            wobble.enabled = true;
            Destroy(this.gameObject);
        }
    }
}
