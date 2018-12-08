using System;
using Assets.Controllers;
using Assets.GameObjects.Heroes;
using Assets.GameObjects.Weapons;
using Assets.ScriptableObjects;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.GameObjects.Characters
{
    public class ScriptableCharacter : MonoBehaviour, IHero
    {
        [SerializeField]
        private HeroHealth health;

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
        [SerializeField]
        private Hero[] Heroes;

        private InputController inputController;
        private Hero currentHero;

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


        void Start()
        {
            var index = PlayerPrefs.GetInt("SelectedHero");
            currentHero = Heroes[index];

            Jumping = currentHero.Jumping;
            Speed = currentHero.Speed;
            Strength = currentHero.Strength;
            Health.InitializeWithHealth(currentHero.Life);
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
            if (health.isDead || transform.position.y < -50) //dies because falling of the ground 
            {
                Time.timeScale = 0;
                currentHero.isDead = true;
                heroMenuController.ShowMenu();
            }
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

    }
}
