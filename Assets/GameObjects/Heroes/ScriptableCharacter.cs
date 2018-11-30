using System;
using Assets.Controllers;
using Assets.GameObjects.Heroes;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.GameObjects.Characters
{
    public class ScriptableCharacter : MonoBehaviour, IHero
    {
        private bool isAttacking;
        private float attackTimer = 0;
        private float attackCd = 0.3f;
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
        private float _attackDmg;

        [SerializeField]
        private float _shootDmg;

        [SerializeField]
        private InputController inputController;
        [SerializeField]
        private BonusItemController bonusItemController;

        public Text LifeText;
        public Collider2D attackTrigger;
        private Rigidbody2D rb;
        private SphereCollider col;
        private bool lookingRight = true;

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

        public float AttackDmg
        {
            get
            {
                return _attackDmg;
            }

            set
            {
                _attackDmg = value;
            }
        }

        public float ShootDmg
        {
            get
            {
                return _shootDmg;
            }
            set
            {
                _shootDmg = value;
            }
        }


        public void Awake()
        {
            this.attackTrigger.enabled = false;
        }

        void Start()
        {
            inputController.MoveRight += this.MoveRight;
            inputController.MoveLeft += this.MoveLeft;
            inputController.Jump += this.Jump;
            inputController.Attack += this.Attack;
            rb = GetComponent<Rigidbody2D>();
            col = GetComponent<SphereCollider>();
        }

        void FixedUpdate()
        {
            LifeText.text = Life.ToString();
            if (isAttacking)
            {
                if (attackTimer > 0)
                {
                    attackTimer -= Time.deltaTime;
                }
                else
                {
                    isAttacking = false;
                    attackTrigger.enabled = false;
                }
            }
        }

        public void Shoot()
        {

        }

        public void Attack()
        {
            isAttacking = true;
            attackTimer = attackCd;
            attackTrigger.enabled = true;
        }

        public void Die()
        {
            throw new NotImplementedException();
        }

        public void Jump()
        {
            if (!isJumping)
            {
                rb.AddForce(Vector2.up * Jumping * 10 );
                isJumping = true;
            }
        }


        public void MoveRight()
        {
            if (!lookingRight)
            {
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                lookingRight = true;
            }
            transform.Translate(Vector2.right * Time.deltaTime * Speed);
        }

        public void MoveLeft()
        {
            if (lookingRight)
            {
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                lookingRight = false;
            }
            transform.Translate(Vector2.left * Time.deltaTime * Speed);
        }

        public void Move()
        {
            
        }

        public void TakeDamage(double damage)
        {
            throw new NotImplementedException();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("ground") 
                || col.gameObject.CompareTag("enemy"))
            {
                isJumping = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("enemy"))
            {
                col.SendMessageUpwards("TakeDamage", this.AttackDmg);
            }

            else if (col.CompareTag("bonus"))
            {
                bonusItemController.Consume(col, this);
            }
        }
    }
}
