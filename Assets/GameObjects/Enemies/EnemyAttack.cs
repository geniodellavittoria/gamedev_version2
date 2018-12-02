using UnityEngine;
using System.Collections;
using Assets.GameObjects.Characters;
using Assets.GameObjects.Heroes;
using System;

namespace Assets.GameObjects.Enemies
{

    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField]
        private float attackSpeed;

        [SerializeField]
        private int attackDmg;

        [SerializeField]
        private Health health;

        private GameObject hero;
        private HeroHealth heroHealth;

        bool heroInRange;
        float timer;

        private void Awake()
        {
            hero = GameObject.FindGameObjectWithTag("hero");
            if (hero == null)
            {
                Debug.LogError("No hero with hero tag defined");
            }
            heroHealth = hero.GetComponent<HeroHealth>();
        }

        // Update is called once per frame
        void Update()
        {
            timer += Time.deltaTime;
            if (timer >= attackSpeed && heroInRange && !health.isDead)
            {
                Attack();
            }

        }

        private void Attack()
        {
            timer = 0f;
            if (!heroHealth.isDead)
            {
                heroHealth.TakeDamage(attackDmg);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject == hero)
            {
                heroInRange = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject == hero)
            {
                heroInRange = false;
            }
        }
    }
}
