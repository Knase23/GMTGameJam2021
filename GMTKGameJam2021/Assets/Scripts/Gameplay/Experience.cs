using UnityEngine;

namespace Gameplay
{
    public class Experience : MonoBehaviour
    {
        public Integer points;

        public void Add(int value)
        {
            points.value += value;
        }
    }
}
