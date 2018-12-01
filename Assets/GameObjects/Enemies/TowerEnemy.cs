using UnityEngine;
using System.Collections;
using Assets.GameObjects.Weapons;
using Assets.Controllers;

namespace Assets.GameObjects.Enemies
{
    public class TowerEnemy : MonoBehaviour, IEnemy
    {
        [SerializeField]
        public GameObject GameManager;
        private ShotController ShotController;

        public float fireRate;

        private float nextFire;

        [SerializeField]
        public GameObject Shot;

        [SerializeField]
        private float _speed;

        [SerializeField]
        private float _life;

        [SerializeField]
        private float _strength;

        [SerializeField]
        private bool _isDead;

        [SerializeField]
        private float _shootDmg;

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
        public float Life
        {
            get
            {
                return _life;
            }
            set
            {
                _life = value;
            }
        }
        public float Strength
        {
            get
            {
                return _strength;
            }
            set
            {
                _strength = value;
            }
        }
        public bool IsDead
        {
            get
            {
                return _isDead;
            }
            set
            {
                _isDead = value;
            }
        }
        public float ShootDmg
        {
            get
            {
                return _shootDmg;
            }
            set
            {
                _shootDmg = value;
            }
        }
        public void Shoot()
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;

                var shot = Instantiate(Shot, gameObject.transform.position, Quaternion.identity);
                shot.transform.parent = GameObject.Find("Shots").transform;

                shot.GetComponent<Shot>().ShotSpeed = 2;
                shot.GetComponent<Shot>().ShotDamage = this.ShootDmg;
                shot.GetComponent<Shot>().IsEnemyShot = true;


                ShotController.Shoot(shot);
            }
        }

        public void Die()
        {
            Destroy(gameObject);
        }

        public void Move()
        {
            throw new System.NotImplementedException();
        }

        public void TakeDamage(float damage)
        {
            this.Life -= damage;
        }

        // Use this for initialization
        void Start()
        {
            ShotController = GameManager.GetComponent<ShotController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (this.Life <= 0)
            {
                Die();
            }
            Shoot();
        }

    }
}
