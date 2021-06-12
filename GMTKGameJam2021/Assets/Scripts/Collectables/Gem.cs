using System.Collections;
using Gameplay;
using UnityEngine;

namespace Collectables
{
    public class Gem : Collectible
    {
        public int value;
        public BoxCollider triggerBoxCollider;
        public override void OnCollect(Collect collector)
        {
            // add exp based on value;
            collector.experience.Add(value);
            base.OnCollect(collector);
        }

        public override IEnumerator OnSpawn()
        {
            triggerBoxCollider.enabled = false;
            yield return new WaitForSeconds(0.5f);
            triggerBoxCollider.enabled = true;
        }

        public override int GetNumericValue()
        {
            return value;
        }
    }
}
