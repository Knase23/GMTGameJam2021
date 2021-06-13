using System;
using UnityEngine;

namespace Gameplay
{
    public class Experience : MonoBehaviour
    {
        public Integer points;
        public Integer maxExp;
        public Integer level;

        public void OnDestroy()
        {
            //
            points.value = 0;
            level.value = 0;
        }

        public void Add(int value)
        {
            points += value;
            if (points >= maxExp)
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            level.value++;
            points.value = 0;
        }
    }
}
