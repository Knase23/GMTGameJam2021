using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Utility
{
    public class SpawnManager : MonoBehaviour
    {
        private static SpawnManager _singleton;
        private Dictionary<Spawnable, GameObject> spawnableDictionary = new Dictionary<Spawnable, GameObject>();

        //These need to correspond to their Prefab Names
        public enum Spawnable
        {
            NONE,
            GEM_SMALL,
            GEM_MEDIUM,
            GEM_LARGE,
            GEM_HUGE,
            GEM_GIGANTIC,
        }
        //
        // [Serializable]
        // public struct SpawnableObject
        // {
        //     public Spawnable Name;
        //     public GameObject Prefab;
        //     public SpawnableObject(Spawnable type, GameObject prefab)
        //     {
        //         Name = type;
        //         Prefab = prefab;
        //     }
        // }

        public void Awake()
        {
            if (_singleton)
            {
                Destroy(this);
            }
            else
            {
                _singleton = this;
            }
        }

        public void Start()
        {
            GameObject[] gameObjects = Resources.LoadAll<GameObject>("Spawnable/");
            foreach (GameObject o in gameObjects)
            {
                Collectible c = o.GetComponent<Collectible>();
                Debug.Log(c);
                if (c)
                {
                    if(c.spawnType == Spawnable.NONE) continue;
                    if (spawnableDictionary.ContainsKey(c.spawnType))
                    {
                        Debug.Log("Could not add another: "+ c.spawnType + " tried to add Prefab" + o.name);
                        continue;
                    }
                    spawnableDictionary.Add(c.spawnType,o);
                }
            }
        }

        public static void Spawn(Spawnable spawn, Vector3 position)
        {
            if (_singleton == null)
            {
                Debug.LogError("No Spawn Manager in Scene");
                return;
            }
        
            // StartCoroutine()
            if (!_singleton.spawnableDictionary.ContainsKey(spawn))
            {
                Debug.LogWarning("Could not spawn in a " + spawn);
                return;
            }
            GameObject spawned = Instantiate(_singleton.spawnableDictionary[spawn]);
            spawned.transform.position = position;

            IOnSpawn onSpawn = spawned.GetComponent<IOnSpawn>();
            onSpawn?.Spawn();
        }
    }

    interface IOnSpawn
    {
        public IEnumerator OnSpawn();
        public void Spawn();
    }
}