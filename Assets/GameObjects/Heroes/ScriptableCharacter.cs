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
        private bool isAttacking;
        private float attackTimer = 0;
        private float attackCd = 0.3f;
        private bool isJumping;
        [SerializeField]
        private float _jumping;

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

        [SerializeField]
        private float _attackDmg;

        [SerializeField]
        private float _shotDmg;

        [SerializeField]
        private float _shotSpeed = 1;

        [SerializeField]
        private HeroMenuController heroMenuController;
        [SerializeField]
        private GameObject GameManager;

        private InputController inputController;
        private ShotController shotController;

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

        public float ShotDmg
        {
            get
            {
                return _shotDmg;
            }
            set
            {
                _shotDmg = value;
            }
        }

        public float ShotSpeed
        {
            get
            {
                return _shotSpeed;
            }
            set
            {
                _shotSpeed = value;
            }
        }


        public void Awake()
        {
            this.attackTrigger.enabled = false;
        }

        void Start()
        {
            shotController = GameManager.GetComponent<ShotController>();
            inputController = GameManager.GetComponent<InputController>();
            inputController.MoveRight += MoveRight;
            inputController.MoveLeft += MoveLeft;
            inputController.Jump += Jump;
            inputController.Attack += Attack;
            inputController.Shoot += Shoot;
            rb = GetComponent<Rigidbody2D>();
            col = GetComponent<SphereCollider>();
        }

        void FixedUpdate()
        {
            if (this.Life <= 0)
            {
                Die();
            }
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
            var shot = shotController.Shoot(gameObject);
            shot.transform.rotation = transform.rotation;
            shot.transform.position = transform.position + transform.forward;

            if (Direction == Direction.Right)
            {
                shot.GetComponent<Rigidbody2D>().velocity = Vector2.right * ShotSpeed;
            }
            else
            {
                //shot.transform.position = new Vector2(-transform.localScale.x, transform.localScale.y);
                shot.GetComponent<Rigidbody2D>().velocity = Vector2.left * ShotSpeed;
            }
            print(shot.GetComponent<Rigidbody2D>().velocity);

            shot.GetComponent<Shot>().ShotSpeed = _shotSpeed;
            shot.GetComponent<Shot>().ShotDamage = ShotDmg;
            shot.GetComponent<Shot>().IsEnemyShot = false;
            shot.SetActive(true);
        }

        public void Attack()
        {
            isAttacking = true;
            attackTimer = attackCd;
            attackTrigger.enabled = true;
        }

        public void Die()
        {
            this.IsDead = true;
            heroMenuController.ShowMenu();
        }

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

        public void Move()
        {

        }

        public void TakeDamage(float damage)
        {
            this.Life -= damage;
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
