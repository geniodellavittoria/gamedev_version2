using UnityEngine;
using System.Collections;
using Assets.Controllers;

namespace Assets.GameObjects.Weapons
{
    public class ShootAttack : MonoBehaviour, IAttack
    {
        [SerializeField]
        private GameObject _gameManager;
        private ShotController shotController;

        [SerializeField]
        private float _speed = 0.3f;

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
                return _gameManager;
            }

            set
            {
                _gameManager = value;
            }
        }

        public ShotController ShotController
        {
            get
            {
                return shotController;
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
            throw new System.NotImplementedException();
        }

        protected void Start()
        {
            shotController = InputManager.GetComponent<ShotController>();
            if (shotController == null)
            {
                Debug.LogError("GameObject does not contain shootController");
            }
        }

        protected void Shoot(GameObject shot)
        {
            shot.GetComponent<Shot>().Shooter = gameObject;
            shot.SetActive(true);
            Timer = 0f;
        }




    }
}
