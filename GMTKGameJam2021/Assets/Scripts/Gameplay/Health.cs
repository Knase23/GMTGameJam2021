using UnityEngine;

namespace Gameplay
{
    public class Health : MonoBehaviour
    {
        public Integer healthScore;
        
        public void TakeDamage(int value)
        {
            healthScore.value -= value;
            //Remove one Follow bullet AI
        }

        public void Heal(int value)
        {
            healthScore.value += value; 
            //Add one Follow bullet AI 
        }
    }
}
