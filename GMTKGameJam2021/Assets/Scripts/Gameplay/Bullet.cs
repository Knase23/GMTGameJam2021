using System;
using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        private bool hitSomething;
        private Rigidbody _rigidbody;
        public State current;

        public float speed;
        public enum State
        {
            Bullet,
            Collect,
        }

        public void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        public void Throw(Vector3 startPosition, Vector3 direction)
        {
            current = State.Bullet;
            transform.position = startPosition + direction;
            _rigidbody.velocity = direction * speed;
        }

        public void OnTriggerEnter(Collider other)
        {
            if (current == State.Bullet)
            {
                Health health = other.GetComponent<Health>();
                if (health)
                {
                    health.TakeDamage(1);
                    Destroy(gameObject);
                }

                current = State.Collect;
            }
            if (current == State.Collect)
            {
                Collect collect = other.GetComponent<Collect>();
                if (collect)
                {
                    //Do Something
                    
                }



            }
            
        }
    }
}