using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
public class AINavigation : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float speed;

    public Vector3 targetPosition;
    private float elapsed;
    private int pathIndex;
    private NavMeshPath path;

    private bool pause;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        path = new NavMeshPath();
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed > 1.0f)
        {
            elapsed -= 1.0f;
            NavMesh.CalculatePath(transform.position, targetPosition, NavMesh.AllAreas, path);
            pathIndex = 0;
        }

        if (path.status == NavMeshPathStatus.PathComplete)
        {
            if (Vector3.Distance(path.corners[pathIndex], transform.position) < 1)
            {
                pathIndex++;
                if (pathIndex >= path.corners.Length)
                {
                    pathIndex = path.corners.Length - 1;
                }
            }
            for (int i = 0; i < path.corners.Length - 1; i++)
                Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
        }
        
        Vector3 calculatedDirection = Vector3.zero;
        if (!pause && path.status == NavMeshPathStatus.PathComplete)
        {
            calculatedDirection = path.corners[pathIndex] - transform.position;
            
        }
        calculatedDirection.Normalize();
        Vector3 velocity = new Vector3(calculatedDirection.x, 0, calculatedDirection.z);
        _rigidbody.velocity = velocity * speed;
    }

    public void Pause()
    {
        pause = true;
        targetPosition = transform.position;
    }

    public void Move(Vector3 destination)
    {
        pause = false;
        targetPosition = destination;
    }
    
}
