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

        [SerializeField]
        public GameObject Shot;

        [SerializeField]
        private float _speed;

        [SerializeField]
        private float _strength;

        [SerializeField]
        private EnemyShootAttack ShootAttack;

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
            GetHeroDirection();
            if (health.isDead)
            {
                Destroy(gameObject);
            }
            ShootAttack.Attack(Direction, Hero);
        }

        private void OnTriggerEnter2D(Collider2D collision)
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

        void OnCollisionEnter2D(Collision2D collision)
        {

        }
    }
}
