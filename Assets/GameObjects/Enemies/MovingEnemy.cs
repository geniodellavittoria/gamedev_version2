﻿using System;
using Assets.Scripts;
using UnityEngine;

namespace Assets.GameObjects.Enemies
{
    public class MovingEnemy : MonoBehaviour, IEnemy
    {
        [SerializeField]
        private float _speed;

        [SerializeField]
        private float _life;

        [SerializeField]
        private float _strength;

        [SerializeField]
        private bool _isEnemy;

        [SerializeField]
        private bool _isDead;

        private Direction Direction = Direction.Right;

        [SerializeField]
        private Collider2D FrontCollider;

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

        public MovingEnemy()
        {

        }

        public void Shoot()
        {
            throw new NotImplementedException();
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

        public void TakeDamage(float damage)
        {
            this.Life -= damage;
        }

        void Update()
        {
            if (this.Life <= 0)
            {
                Die();
            }
            Move();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
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
    }
}
