using UnityEngine;

namespace Gameplay
{
    public class Health : MonoBehaviour
    {
        public Integer healthScore;
        public void TakeDamage(int value)
        {
            healthScore.value -= value;
        }

        public void Heal(int value)
        {
            healthScore.value += value;
        }
    }
}
