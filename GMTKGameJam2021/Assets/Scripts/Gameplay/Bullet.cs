using System;
using System.Collections.Generic;
using Services;
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
        public float airTime = 1;
        public float peakHeight = 2;

        public Transform billboard;
        
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
                if (timer < airTime && hitSomething == false)
                {
                    gameObject.layer = 7;
                    //Fly up
                    timer += Time.deltaTime;

                    if (timer > airTime)
                        timer = airTime;

                    float percentHalf = timer / (airTime * 0.5f);

                    if (percentHalf > 1)
                    {
                        float remover = percentHalf - 1;
                        percentHalf -= remover * 2;
                    }
                    Vector3 pos = billboard.position;
                    pos.y = percentHalf * peakHeight;
                    billboard.position = pos;
                }
                else
                {
                    CollectState();
                }
            }
        }

        public void CollectState()
        {
            Vector3 pos = billboard.position;
            timer = 0;
            pos.y = 0;
            billboard.position = pos;
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

                ServiceLocator.GetService<IAudioService>().PlaySFX("rock_throw_impact");
                CollectState();
            }

            if (current == State.Collect)
            {
                Collect collect = other.GetComponent<Collect>();
                if (collect)
                {
                    collect.shooter.CollectBullet(this);
                }
            }
        }
    }
}