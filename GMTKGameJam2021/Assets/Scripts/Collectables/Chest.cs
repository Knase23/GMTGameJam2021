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
            opened = true;
            do
            {
                List<Collectible> availableAlternatives = contentPrefabs.Where(x => x.GetNumericValue() <= totalChestValue).ToList();
                
                if (availableAlternatives.Count == 0) break;
                availableAlternatives = availableAlternatives.OrderBy(x => Guid.NewGuid()).ToList();
                Collectible collectibleToSpawn = availableAlternatives.Take(1).ToList()[0];
                
                Vector3 spawnPosition = this.transform.position;
                Vector3 circularOffset = UnityEngine.Random.insideUnitCircle * 2;
                spawnPosition += Vector3.right * circularOffset.x;
                spawnPosition += Vector3.forward * circularOffset.y;
                
                
                SpawnManager.Spawn(collectibleToSpawn.spawnType,spawnPosition);
                rend.sprite = openChestSprite;
                
                LeanTween.moveLocalY(rend.gameObject, 0.5f, 1f).setEase(LeanTweenType.punch);
                LeanTween.scale(this.gameObject, Vector3.one * 1.5f, 1f).setEase(LeanTweenType.punch);
                
                totalChestValue -= collectibleToSpawn.GetNumericValue();

            } while (totalChestValue > 0);
            //base.OnCollect(collector);
        }

        public override int GetNumericValue()
        {
            return totalChestValue;
        }

        private void Update()
        {
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                OnCollect(null);
            }
#endif
        }
    }
}
