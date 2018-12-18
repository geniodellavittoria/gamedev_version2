using UnityEngine;
using System.Collections;
using Assets.GameObjects.Weapons;
using Assets.Controllers;
using System;
using Assets.GameObjects.Characters;

namespace Assets.GameObjects.Heroes
{
    public class HeroNearFieldAttack : NearFieldAttack
    {

        private InputController inputController;

        private Health health;

        private float attackTimer = 0;
        [SerializeField]
        private GameObject Sword;

        [SerializeField]
        public Collider2D attackTrigger;

        private bool isAttacking;

        public void Awake()
        {
            this.attackTrigger.enabled = false;
        }

        private void Start()
        {
            inputController = InputManager.GetComponent<InputController>();
            if (inputController == null)
            {
                Debug.LogError("GameObject does not contain inputController");
            }
            inputController.Attack += Attack;
        }

        public void Attack()
        {
            if (!isAttacking)
            {
                isAttacking = true;
                attackTrigger.enabled = true;
                Sword.SetActive(true);
                attackTimer = AttackCoolDown;
            }
        }

        public void Update()
        {
            if (isAttacking)
            {
                if(attackTimer > 0)
                {
                    attackTimer -= Time.deltaTime;
                }
                else
                {
                    isAttacking = false;
                    attackTrigger.enabled = false;
                    Sword.SetActive(false);
                }
            }
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("enemy") && col.isTrigger)
            {
                health = col.gameObject.GetComponentInParent<Health>();
                health.TakeDamage(Damage);
            }
        }

    }
}
