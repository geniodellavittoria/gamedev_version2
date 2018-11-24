using System;
using Assets.Controllers;
using Assets.GameObjects.Hero;
using UnityEngine;

namespace Assets.GameObjects.Character
{
    public class ScriptableCharacter : MonoBehaviour, IHero
    {
        public ScriptableCharacter()
        {
            
        }

        [SerializeField]
        private double _height;

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
        private Rigidbody rb;
        private SphereCollider col;
        private float jumpForce = 7;
        float runSpeed = 10;
        float horizontalMove = 0f;

        public double Height
        {
            get
            {
                return _height;
            }

            set
            {
                _height = value;
            }
        }

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
        
        void Start()
        {
            inputController.Move += this.Move;
            inputController.Jump += this.Jump;
            rb = GetComponent<Rigidbody>();
            col = GetComponent<SphereCollider>();
        }

        void Update()
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

        public void Jump()
        {
            rb.AddForce(Vector2.up * jumpForce);
        }


        public void Move()
        {
            horizontalMove = Input.GetAxis("Horizontal") + runSpeed;

            
        }
        
        public void TakeDamage(double damage)
        {
            throw new NotImplementedException();
        }
    }
}
