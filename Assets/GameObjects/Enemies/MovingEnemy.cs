using System;
using System.Threading;
using Assets.GameObjects.Characters;
using Assets.GameObjects.Heroes;
using Assets.GameObjects.Weapons;
using Assets.Scripts;
using UnityEngine;

namespace Assets.GameObjects.Enemies
{
    public class MovingEnemy : MonoBehaviour, IEnemy
    {
        [SerializeField]
        private Health health;

        [SerializeField]
        private float _speed;

        [SerializeField]
        private float _strength;

        [SerializeField]
        private bool _isEnemy;

        [SerializeField]
        private EnemyNearFieldAttack NearFieldAttack;

        private GameObject hero;
        private HeroHealth heroHealth;

        private Direction Direction = Direction.Right;
        private bool heroInRange;

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

        public bool IsEnemy
        {
            get
            {
                return _isEnemy;
            }
            set
            {
                _isEnemy = value;
            }
        }

        public void Die()
        {
            Destroy(gameObject);
        }

        public void Move()
        {
            if (Direction == Direction.Right)
            {
                transform.Translate(Vector2.right * Time.deltaTime * Speed);

            }
            else
            {
                transform.Translate(Vector2.left * Time.deltaTime * Speed);
            }
        }

        public void TakeDamage(int damage)
        {
            health.TakeDamage(damage);
            if (health.isDead)
            {
                Destroy(gameObject);
            }
        }

        private void Awake()
        {
            hero = GameObject.FindGameObjectWithTag("hero");
            if (hero == null)
            {
                Debug.LogError("No hero with tag Hero defined");
            }
            heroHealth = hero.GetComponent<HeroHealth>();

        }

        void Update()
        {
            if (!health.isDead)
            {
                Move();
            }
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
            var contactSide = ChangeDirection(collision);
            if (contactSide == Direction.Down || contactSide == DirectionMethods.ReverseDirection(Direction))
            {
                return;
            }
            if (collision.gameObject.CompareTag("hero"))
            {
                // todo: handle attack on hero
                return;
            }

            Direction = DirectionMethods.ReverseDirection(Direction);
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            //collision.rigidbody.isKinematic = false;
        }

        private Direction ChangeDirection(Collision2D collision)
        {
            var contactSide = Direction;

            Vector3 contactPoint = collision.contacts[0].point;
            Vector3 center = collision.collider.bounds.center;

            float RectWidth = this.GetComponent<Collider2D>().bounds.size.x;
            float RectHeight = this.GetComponent<Collider2D>().bounds.size.y;

            if (contactPoint.y > center.y)
            {
                contactSide = Direction.Down;
            }
            else if (contactPoint.x > center.x)
            {
                contactSide = Direction.Left;
            }
            else if (contactPoint.x < center.x)
            {
                contactSide = Direction.Right;
            }
            else if (contactPoint.y < center.y)
            {
                contactSide = Direction.Up;
            }

            return contactSide;
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
            if (collision.gameObject == hero)
            {
                heroInRange = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject == hero)
            {
                heroInRange = false;
            }
        }
    }
}
