using UnityEngine;
using System.Collections;
using System;

namespace Assets.GameObjects.Weapons
{

    public class NearFieldAttack : MonoBehaviour, IAttack
    {
        [SerializeField]
        private GameObject _inputManager;

        [SerializeField]
        private float _speed = 0.05f;

        [SerializeField]
        private int _damage;

        [SerializeField]
        private float _attackRate;

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

        }

    }
}
