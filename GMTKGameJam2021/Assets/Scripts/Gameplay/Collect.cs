using System;
using UnityEngine;

namespace Gameplay
{
    public class Collect : MonoBehaviour
    {
        public Experience experience;
        public Health health;
        public Shoot shooter;
        public void Start()
        {
            experience = GetComponent<Experience>();
            health = GetComponent<Health>();
            shooter = GetComponent<Shoot>();
        }
    }
}
