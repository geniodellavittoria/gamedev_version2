using UnityEngine;
using System.Collections;
using Assets.GameObjects.Weapons;
using Assets.Controllers;

namespace Assets.GameObjects.Enemies
{
    public class TowerEnemy : MonoBehaviour, IEnemy
    {
        [SerializeField]
        public ShotController ShotController;

        public float fireRate;

        private float nextFire;

        [SerializeField]
        public GameObject Shot;

        [SerializeField]
        private float _speed;

        [SerializeField]
        private double _life;

        [SerializeField]
        private double _strength;

        [SerializeField]
        private bool _isDead;

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


        public double Life
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
        public double Strength
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

        public void Shoot()
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;

                var shot = Instantiate(Shot, gameObject.transform.position, Quaternion.identity);

                shot.GetComponent<Shot>().ShotSpeed = 2;
                shot.GetComponent<Shot>().ShotDamage = 1;
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

        public void TakeDamage(double damage)
        {
            this.Life -= damage;
        }

        // Use this for initialization
        void Start()
        {

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
