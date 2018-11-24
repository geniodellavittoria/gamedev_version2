using System;
using Assets.Controllers;
using Assets.GameObjects.Hero;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.GameObjects.Character
{
    public class ScriptableCharacter : MonoBehaviour, IHero
    {

        private bool isJumping;
        [SerializeField]
        private float _jumping;

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

        [SerializeField]
        private InputController inputController;
        [SerializeField]
        private BonusItemController bonusItemController;

        public Text LifeText;

        private Rigidbody2D rb;
        private SphereCollider col;

        public float Jumping
        {
            get
            {
                return _jumping;
            }

            set
            {
                _jumping = value;
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
            rb = GetComponent<Rigidbody2D>();
            col = GetComponent<SphereCollider>();
        }

        void Update()
        {
            LifeText.text = Life.ToString();
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
            if (!isJumping)
            {
                rb.AddForce(Vector2.up * Jumping * 10);
                isJumping = true;
            }
        }


        public void Move()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");

            Vector2 movement = new Vector2(moveHorizontal, 0.0f);

            rb.AddForce(movement * Speed);

        }
        
        public void TakeDamage(double damage)
        {
            throw new NotImplementedException();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "ground")
            {
                isJumping = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            bonusItemController.Consume(col,this);
        }
    }
}
