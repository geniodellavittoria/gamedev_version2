using System;
using System.Collections.Generic;
using System.Linq;
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
            print(contactSide);
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
            var directions = new Dictionary<Direction, int>();
            directions.Add(Direction.Left, 0);
            directions.Add(Direction.Right, 0);

            var contactSide = Direction;

            ContactPoint2D[] contactPoints = collision.contacts;
            foreach (ContactPoint2D contactPoint in contactPoints)
            {
                //Vector3 contactPoint = collision.contacts[0].point;
                Vector3 center = collision.collider.bounds.center;

                float RectWidth = this.GetComponent<Collider2D>().bounds.size.x;
                float RectHeight = this.GetComponent<Collider2D>().bounds.size.y;

                if (contactPoint.point.x > center.x)
                {
                    directions[Direction.Left] += 1;
                    contactSide = Direction.Left;
                }
                else if (contactPoint.point.x < center.x)
                {
                    directions[Direction.Right] += 1;
                    contactSide = Direction.Right;
                }
            }
            return directions.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
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
