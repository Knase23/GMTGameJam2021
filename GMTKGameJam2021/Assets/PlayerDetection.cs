using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDetection : MonoBehaviour
{
    public Transform target;
    public AINavigation nav;
    public float detectionDistance = 10;
    private float _catchUpDelay = 0.2f;
    private float _catchUpTimer = 0;

    public UnityEvent OnPlayerDetection;
    public bool detected;
    
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
                if (!detected)
                {
                    OnPlayerDetection?.Invoke();
                    detected = true;
                }
                
                Debug.Log("Player In Range!");
                if (_catchUpTimer > _catchUpDelay)
                    nav.Move(target.position);
                
                _catchUpTimer += Time.deltaTime;
            }
        }
        else
        {
            detected = false;
            nav.Pause();
            _catchUpTimer = 0;
        }
    }
}