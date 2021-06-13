using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderActivators : MonoBehaviour
{

    public Boolean condition;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            condition.flag = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            condition.flag = false;
        }
    }
}
