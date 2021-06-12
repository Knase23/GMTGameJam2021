using System;
using UnityEngine;

namespace Gameplay
{
    public class Experience : MonoBehaviour
    {
        public Integer points;
        public Integer maxExp;

        public void OnDestroy()
        {
          points.value = 0;
        }

        public void Add(int value)
        {
            points += value;
        }
    }
}
