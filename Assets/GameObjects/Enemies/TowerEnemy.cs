using UnityEngine;
using System.Collections;
using Assets.GameObjects.Weapons;
using Assets.Controllers;
using Assets.Scripts;

namespace Assets.GameObjects.Enemies
{
    public class TowerEnemy : MonoBehaviour, IEnemy
    {
        [SerializeField]
        public GameObject GameManager;
        private ShotController ShotController;

        private Direction Direction = Direction.Left;

        [SerializeField]
        public GameObject Hero;

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
        private float _shotDmg = 3;

        [SerializeField]
        private float _shotSpeed = 1;

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
                return _shotDmg;
            }
            set
            {
                _shotDmg = value;
            }
        }

        public void Shoot()
        {
            GetHeroDirection();


            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;

                //var shot = Instantiate(Shot, gameObject.transform.position, gameObject.transform.rotation);
                var shot = ShotController.Shoot(gameObject);
                shot.transform.position = gameObject.transform.position;
                shot.transform.rotation = gameObject.transform.rotation;
                shot.GetComponent<Rigidbody2D>().velocity = (Hero.transform.position - shot.transform.position).normalized * 2;

                shot.GetComponent<Shot>().ShotSpeed = _shotSpeed;
                shot.GetComponent<Shot>().ShotDamage = this.ShootDmg;
                shot.GetComponent<Shot>().IsEnemyShot = true;
                shot.SetActive(true);

            }
        }

        public void GetHeroDirection()
        {
            var position = Hero.transform.position;
            if (position.x < gameObject.transform.position.x && Direction != Direction.Left)
            {
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                Direction = Direction.Left;
            }
            if (position.x > gameObject.transform.position.x && Direction != Direction.Right)
            {
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                Direction = Direction.Right;
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
