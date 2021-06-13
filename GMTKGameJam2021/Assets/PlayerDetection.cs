using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public Transform target;
    public AINavigation nav;
    public float detectionDistance = 10;
    private float _catchUpDelay = 0.2f;
    private float _catchUpTimer = 0;

    void Start()
    {
        nav = GetComponent<AINavigation>();
    }

    void Update()
    {
        float distanceFromTarget = Vector3.Distance(transform.position, target.position);
        if (distanceFromTarget < 2f)
        {
            nav.Pause();
            _catchUpTimer = 0;
            return;
        }

        if (!Physics.Linecast(transform.position + Vector3.up * 0.1f, target.position + Vector3.up * 0.1f, out RaycastHit hit ,LayerMask.GetMask("Default","Player"))) return;
        if (hit.transform == target)
        {
            if (distanceFromTarget < detectionDistance)
            {
                if (_catchUpTimer > _catchUpDelay)
                    nav.Move(target.position);
                _catchUpTimer += Time.deltaTime;
            }
        }
        else
        {
            nav.Pause();
            _catchUpTimer = 0;
        }
    }
}