using UnityEngine;

namespace Gameplay
{
    public class Experience : MonoBehaviour
    {
        private int _value;

        public void Add(int value)
        {
            _value += value;
        }
    }
}
