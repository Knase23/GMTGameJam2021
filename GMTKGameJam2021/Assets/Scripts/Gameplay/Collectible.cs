using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(BoxCollider))]
    public abstract class Collectible : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collision)
        {
            Debug.Log($"{collision.name} hit {name}");
            Collect collector = collision.GetComponent<Collect>();
            if (collector)
            {
                OnCollect(collector);
            }
        }

        public virtual void OnCollect(Collect collector)
        {
            //Maybe change to object pooling!
            Destroy(gameObject);
        }

        public abstract int GetNumericValue();
    }
}
