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


        private void Start()
        {
            Nature = GroundNature.Lava;
            Value = lavaDamage;
        }

        public void Update()
        {
            timer += Time.deltaTime;
            if (HeroOnGround)
            {
                if (timer >= damageRate)
                {
                    Hero.GetComponent<HeroHealth>().TakeDamage(lavaDamage);
                    timer = 0f;
                }
            }
        }


    }
}
