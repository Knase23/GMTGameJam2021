using System;
using System.Collections.Generic;
using System.Linq;
using Gameplay;
using UnityEngine;

namespace Collectables
{
    public class Chest : Collectible
    {
        public int totalChestValue;
        public bool opened;
        public List<Collectible> contentPrefabs;

        public SpriteRenderer rend;
        public Sprite openChestSprite;

        public override void OnCollect(Collect collector)
        {
            if (opened) return;
            Debug.Log("Chest Spit out!");
            opened = true;
            do
            {
                List<Collectible> availableAlternatives = contentPrefabs.Where(x => x.GetNumericValue() <= totalChestValue).ToList();
                if (availableAlternatives.Count == 0) break;
                availableAlternatives = availableAlternatives.OrderBy(x => Guid.NewGuid()).ToList();
                Collectible collectibleToSpawn = availableAlternatives.Take(1).ToList()[0];
                GameObject spawned = Instantiate(collectibleToSpawn.gameObject);
                spawned.transform.position = this.transform.position;
                Vector3 circularOffset = UnityEngine.Random.insideUnitCircle * 2;
                spawned.transform.position += Vector3.right * circularOffset.x;
                spawned.transform.position += Vector3.forward * circularOffset.y;
                rend.sprite = openChestSprite;
                totalChestValue -= collectibleToSpawn.GetNumericValue();

            } while (totalChestValue > 0);
            //base.OnCollect(collector);
        }
    
        public override int GetNumericValue()
        {
            return totalChestValue;
        }
    }
}
