using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        private bool hitSomething;
        private Rigidbody _rigidbody;
        public State current;

        public static List<Bullet> currentAvailableBullets = new List<Bullet>();
        
        
        public float speed;
        private float timer;

        public Transform holder;
        public enum State
        {
            Bullet,
            Collect,
        }

        public void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            currentAvailableBullets.Add(this);
            CollectState();
        }
        private void OnDestroy()
        {
            currentAvailableBullets.Remove(this);
        }

        public void Throw(Vector3 startPosition, Vector3 direction)
        {
            transform.position = startPosition + direction;
            _rigidbody.velocity = direction * speed;
            BulletState();
        }

        private void Update()
        {
            if (current == State.Bullet)
            {

                timer += Time.deltaTime;

                if (timer > 1)
                {
                    timer = 0;
                    CollectState();
                }
            }
        }

        public void CollectState()
        {
            holder = null;
            current = State.Collect;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.isKinematic = true;
            int layer = 10; // Collectable
            gameObject.layer = layer;
        }

        public void BulletState()
        {
            current = State.Bullet;
            _rigidbody.isKinematic = false;
            int layer = 7; // Bullets
            gameObject.layer = layer;
        }
        
        public void OnTriggerEnter(Collider other)
        {
            if (current == State.Bullet)
            {
                Health health = other.GetComponent<Health>();
                if (health)
                {
                    Debug.Log("Destroy!");
                    health.TakeDamage(1);
                    Destroy(gameObject);
                }

                CollectState();
            }
        }
    }
}