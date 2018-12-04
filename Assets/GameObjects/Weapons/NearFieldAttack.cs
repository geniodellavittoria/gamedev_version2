using UnityEngine;
using System.Collections;
using System;
using Assets.GameObjects.Heroes;

namespace Assets.GameObjects.Weapons
{

    public class NearFieldAttack : MonoBehaviour, IAttack
    {
        [SerializeField]
        private GameObject _inputManager;

        [SerializeField]
        private GameObject hero;

        [SerializeField]
        private float _speed = 0.05f;

        [SerializeField]
        private int _damage;

        [SerializeField]
        private float _attackRate;

        private bool _isInRange;

        private float _timer;

        public int Damage
        {
            get
            {
                return _damage;
            }

            set
            {
                _damage = value;
            }
        }

        public float Speed
        {
            get
            {
                return _speed;
            }

            set
            {
                _speed = value;
            }
        }

        public float Timer
        {
            get
            {
                return _timer;
            }

            set
            {
                _timer = value;
            }
        }

        public GameObject InputManager
        {
            get
            {
                return _inputManager;
            }

            set
            {
                _inputManager = value;
            }
        }

        public float AttackRate
        {
            get
            {
                return _attackRate;
            }

            set
            {
                _attackRate = value;
            }
        }

        public bool IsInRange
        {
            get
            {
                return _isInRange;
            }
            set
            {
                _isInRange = value;
            }
        }

        public void Attack()
        {
            Timer += Time.deltaTime;

            if (Timer >= AttackRate)
            {
                AttackNearField();
            }
        }

        protected void AttackNearField()
        {
            if (IsInRange)
            {
                hero.GetComponent<HeroHealth>().TakeDamage(Damage);
                Timer = 0f;
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("hero"))
            {
                IsInRange = true;
            }
        }

        private void OnCollisionExit2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("hero"))
            {
                IsInRange = false;
            }
        }

    }
}
