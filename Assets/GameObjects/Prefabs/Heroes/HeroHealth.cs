using UnityEngine;
using System.Collections;
using Assets.GameObjects.Characters;
using UnityEngine.UI;
using System;

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

        [SerializeField]
        private Image ImmutableImage;

        private float strength = 1f;

        public Color flashColour = new Color(1f, 0, 0, 0.1f);

        public float Strength
        {
            get
            {
                return strength;
            }
            set
            {
                strength = value;
            }
        }

        public bool Immutable
        {
            get
            {
                return _immutable;
            }
            set
            {
                _immutable = value;
                if (_immutable)
                {
                    ImmutableImage.enabled = true;
                }
                else
                {
                    ImmutableImage.enabled = false;
                }
            }
        }

        public void InitializeHealth(int current, int max)
        {
            this.isDead = false;
            currentHealth = current;
            healthSlider.maxValue = max;
            healthSlider.value = currentHealth;
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
                currentHealth -= (int)Math.Floor(amount / (strength / 10));

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
