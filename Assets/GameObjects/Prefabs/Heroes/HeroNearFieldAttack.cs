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
            Timer += Time.deltaTime;

            if (Timer >= AttackRate)
            {
                isAttacking = true;
                attackTrigger.enabled = true;
                NearFieldAttack();
                Timer = 0f;
            }
        }

        private void NearFieldAttack()
        {
            if (IsInRange && health != null)
            {
                //var health = enemy.GetComponent<Health>();
                health.TakeDamage(Damage);
            }
            isAttacking = false;
            attackTrigger.enabled = false;
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("enemy") && col.isTrigger)
            {
                IsInRange = true;
                health = col.gameObject.GetComponentInParent<Health>();
            }
        }

        public void OnTriggerExit2D(Collider2D col)
        {
            if (col.CompareTag("enemy") && col.isTrigger)
            {
                IsInRange = false;
            }
        }

    }
}
