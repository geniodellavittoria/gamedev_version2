using UnityEngine;
using System.Collections;
using Assets.GameObjects.Characters;
using UnityEngine.UI;

namespace Assets.GameObjects.Heroes
{

    public class HeroHealth : Health
    {
        [SerializeField]
        private Slider healthSlider;

        [SerializeField]
        private Image damageImage;

        [SerializeField]
        private bool _immutable = false;

        public Color flashColour = new Color(1f, 0, 0, 0.1f);

        public bool Immutable
        {
            get
            {
                return _immutable;
            }
            set
            {
                _immutable = value;
            }
        }

        public void InitializeWithHealth(int health)
        {
            currentHealth = health;
            healthSlider.maxValue = health;
            healthSlider.value = health;
        }


        void Update()
        {
            if (damaged)
            {
                damageImage.color = flashColour;
            }
            else
            {
                damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            }
            damaged = false;
        }

        public new void TakeDamage(int amount)
        {
            if (!Immutable)
            {
                damaged = true;
                currentHealth -= amount;

                healthSlider.value = currentHealth;
            }

            if (currentHealth <= 0 && !isDead)
            {
                Die();
            }
        }

        public new void AddHealth(int amount)
        {
            base.AddHealth(amount);
            healthSlider.value = currentHealth;
        }
    }
}
