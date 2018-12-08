using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Assets.GameObjects.Characters
{

    public class Health : MonoBehaviour
    {
        public int startingHealth = 50;
        public int currentHealth;

        public float flashSpeed = 5f;


        public bool isDead { get; set; }
        protected bool damaged;
        // Use this for initialization
        void Awake()
        {
            currentHealth = startingHealth;
        }

        public void TakeDamage(int amount)
        {
            damaged = true;
            currentHealth -= amount;

            if (currentHealth <= 0 && !isDead)
            {
                Die();
            }
        }

        public void AddHealth(int amount)
        {
            if (!isDead)
            {
                currentHealth += amount;
                if (currentHealth >= startingHealth)
                {
                    currentHealth = startingHealth;
                }

            }
        }

        protected void Die()
        {
            isDead = true;
        }
    }

}