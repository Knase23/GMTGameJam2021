using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Chest : Collectible
{
    public int totalChestValue;
    public bool opened;
    public List<Collectible> contentPrefabs;

    public SpriteRenderer rend;
    public Sprite openChestSprite;

    public override void Collect()
    {
        if (opened) return;
        opened = true;

        do
        {
            List<Collectible> avaliableAlternatives = contentPrefabs.Where(x => x.getNumericValue() <= totalChestValue).ToList();
            if (avaliableAlternatives.Count == 0) break;
            avaliableAlternatives = avaliableAlternatives.OrderBy(x => Guid.NewGuid()).ToList();
            Collectible collectibleToSpawn = avaliableAlternatives.Take(1).ToList()[0];
            GameObject spawned = Instantiate(collectibleToSpawn.gameObject);
            spawned.transform.position = this.transform.position;
            Vector3 circularOffset = UnityEngine.Random.insideUnitCircle * 2;
            spawned.transform.position += Vector3.right * circularOffset.x;
            spawned.transform.position += Vector3.forward * circularOffset.y;
            rend.sprite = openChestSprite;
            totalChestValue -= collectibleToSpawn.getNumericValue();

        } while (totalChestValue > 0);

    }

    public override int getNumericValue()
    {
        return totalChestValue;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Collect();
        }
#endif
    }
}
