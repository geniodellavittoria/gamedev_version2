using System;
using Assets.GameObjects.Heroes;
using UnityEngine;

namespace Assets.GameObjects.Grounds
{
    public class LavaGround : Ground
    {
        [SerializeField]
        private int lavaDamage;

        [SerializeField]
        private float damageRate;

        private float timer;

        private bool heroOnGround = false;

        private void Start()
        {
            Nature = GroundNature.Lava;
            Value = lavaDamage;
        }

        public void Update()
        {
            timer += Time.deltaTime;

            if (timer >= damageRate && heroOnGround)
            {
                Hero.GetComponent<HeroHealth>().TakeDamage(lavaDamage);
                timer = 0f;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("hero"))
            {
                heroOnGround = true;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("hero"))
            {
                heroOnGround = false;
            }
        }
    }
}
