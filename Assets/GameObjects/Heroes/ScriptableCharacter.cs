using System;
using Assets.Controllers;
using Assets.GameObjects.Heroes;
using Assets.GameObjects.Weapons;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.GameObjects.Characters
{
    public class ScriptableCharacter : MonoBehaviour, IHero
    {
        [SerializeField]
        private HeroHealth health;

        private bool isAttacking;

        private bool isJumping;
        [SerializeField]
        private float _jumping;

        [SerializeField]
        private float _speed;

        [SerializeField]
        private float _strength;

        [SerializeField]
        private bool _isEnemy = false;

        [SerializeField]
        private HeroNearFieldAttack nearFieldAttack;

        [SerializeField]
        private HeroShootAttack shootAttack;

        [SerializeField]
        private HeroMenuController heroMenuController;
        [SerializeField]
        private GameObject GameManager;

        private InputController inputController;

        [SerializeField]
        private BonusItemController bonusItemController;

        public Text LifeText;
        public Collider2D attackTrigger;
        private Rigidbody2D rb;
        private SphereCollider col;
        private Direction Direction = Direction.Right;

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

        public HeroHealth Health
        {
            get
            {
                return health;
            }
        }


        public void Awake()
        {
            this.attackTrigger.enabled = false;
        }

        void Start()
        {
            inputController = GameManager.GetComponent<InputController>();
            inputController.MoveRight += MoveRight;
            inputController.MoveLeft += MoveLeft;
            inputController.Jump += Jump;
            //inputController.Attack += Attack;
            rb = GetComponent<Rigidbody2D>();
            col = GetComponent<SphereCollider>();
        }

        void FixedUpdate()
        {
            if (health.isDead)
            {
                heroMenuController.ShowMenu();
            }

            /*if (isAttacking)
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
            }*/
        }

        /*public void Attack()
        {
            isAttacking = true;
            attackTimer = attackCd;
            attackTrigger.enabled = true;
        }*/

        public void Jump()
        {
            if (!isJumping)
            {
                rb.AddForce(Vector2.up * Jumping * 10);
                isJumping = true;
            }
        }

        public void MoveRight()
        {
            if (Direction != Direction.Right)
            {
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                Direction = Direction.Right;
            }
            transform.Translate(Vector2.right * Time.deltaTime * Speed);
        }

        public void MoveLeft()
        {
            if (Direction == Direction.Right)
            {
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                Direction = Direction.Left;
            }
            transform.Translate(Vector2.left * Time.deltaTime * Speed);
        }

        public void TakeDamage(int damage)
        {
            health.TakeDamage(damage);
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
                //col.SendMessageUpwards("TakeDamage", this.AttackDmg);
            }

            else if (col.CompareTag("bonus"))
            {
                bonusItemController.Consume(col, this);
            }
        }

    }
}
