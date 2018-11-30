using System;
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

        private bool movingRight = true;

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
            if (movingRight)
            {
                transform.Translate(Vector2.left * Time.deltaTime * Speed);
            }
            else
            {
                transform.Translate(Vector2.right * Time.deltaTime * Speed);
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
            movingRight = !movingRight;
            //collision.rigidbody.isKinematic = true;
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            //collision.rigidbody.isKinematic = false;
        }
    }
}
