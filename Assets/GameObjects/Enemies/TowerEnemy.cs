using UnityEngine;
using System.Collections;
using Assets.GameObjects.Weapons;
using Assets.Controllers;
using Assets.Scripts;
using Assets.GameObjects.Characters;

namespace Assets.GameObjects.Enemies
{
    public class TowerEnemy : MonoBehaviour, IEnemy
    {
        [SerializeField]
        private Health health;

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
        private float _strength;

        [SerializeField]
        private int _shotDmg = 3;

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

        public int ShotDmg
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

        public float ShotSpeed
        {
            get
            {
                return _shotSpeed;
            }
            set
            {
                _shotSpeed = value;
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

                shot.GetComponent<Shot>().ShotSpeed = ShotSpeed;
                shot.GetComponent<Shot>().ShotDamage = ShotDmg;
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

        public void Move()
        {
            return;
        }

        public void TakeDamage(int damage)
        {
            health.TakeDamage(damage);
        }

        // Use this for initialization
        void Start()
        {
            ShotController = GameManager.GetComponent<ShotController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (health.isDead)
            {
                Destroy(gameObject);
            }
            Shoot();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("shot"))
            {
                var shot = collision.gameObject.GetComponent<Shot>();
                if (!shot.IsEnemyShot)
                {
                    TakeDamage(shot.ShotDamage);
                }
            }
        }
    }
}
