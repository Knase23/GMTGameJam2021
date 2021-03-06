using System.Collections;
using Gameplay.Utility;
using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(BoxCollider))]
    public abstract class Collectible : MonoBehaviour, IOnSpawn
    {
        public SpawnManager.Spawnable spawnType;
        private void OnTriggerEnter(Collider collision)
        {
            Collect collector = collision.GetComponent<Collect>();
            if (collector)
            {
                OnCollect(collector);
            }
        }

        public virtual IEnumerator OnSpawn()
        {
            yield return null;
        }

        public void Spawn()
        {
            StartCoroutine(OnSpawn());
        }

        public virtual void OnCollect(Collect collector)
        {
            //Maybe change to object pooling!
            Destroy(gameObject);
        }

        public abstract int GetNumericValue();
    }
}