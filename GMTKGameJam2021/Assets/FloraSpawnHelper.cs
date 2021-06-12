using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloraSpawnHelper : MonoBehaviour
{
    public int amountToSpawn;
    public float maxDistance;
    public List<Sprite> collection;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountToSpawn; i++)
        {
            SpriteRenderer rend = new GameObject().AddComponent<SpriteRenderer>();
            rend.sprite = collection[Random.Range(0, collection.Count)];
            rend.transform.SetParent(transform);
            Vector3 pos = Random.insideUnitSphere * maxDistance;
            pos.y = 0;
            rend.transform.position = pos;
            rend.name = rend.sprite.name;
        }
    }
}
