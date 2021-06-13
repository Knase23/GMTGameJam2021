using System;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public class Health : MonoBehaviour
    {
        public Integer healthScore;
        public Integer maxHealth;
        public UnityEvent OnDeath;
        
        public int healthPoint;
        
        public void Start()
        {
            if(healthScore && maxHealth)
                healthScore.value = maxHealth.value;
        }

        public void TakeDamage(int value)
        {
            if (healthScore)
            {
                healthScore.value -= value;

                if (healthScore.value <= 0)
                {
                    OnDeath?.Invoke();
                }
            }
            else
            {
                healthPoint -= value;

                if (healthPoint <= 0)
                {
                    OnDeath?.Invoke();
                }
            }
            
        }

        public void Heal(int value)
        {
            if (healthScore)
            {
                healthScore.value += value;
            }
            else
            {
                healthPoint += value;
            }
        }
    }
}
