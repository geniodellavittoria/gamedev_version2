using System;
using UnityEngine;

namespace Assets.GameObjects.Enemies
{
    public class MovingEnemy : MonoBehaviour, IEnemy
    {
        [SerializeField]
        private float _speed;

        [SerializeField]
        private double _life;

        [SerializeField]
        private double _strength;

        [SerializeField]
        private bool _isEnemy;

        [SerializeField]
        private bool _isDead;

        private bool MovingForward = true;

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

        public void Attack()
        {
            throw new NotImplementedException();
        }

        public void Die()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            var newPosition = transform.position.x + _speed;
                //Physics.CheckBox(new Vector2(newPositon, transform.position.y))
                transform.position = new Vector2(newPosition, transform.position.y);
            //transform.Translate(Vector2. .forward * Time.deltaTime);
        }

        public void TakeDamage(double damage)
        {
            throw new NotImplementedException();
        }

        void Update()
        {
            Move();
        }

        void OnCollisionEnter(Collision collision)
        {
            MovingForward = !MovingForward;
            collision.rigidbody.isKinematic = true;
        }

        void OnCollisionExit(Collision collision)
        {
            collision.rigidbody.isKinematic = false;
        }
    }
}
