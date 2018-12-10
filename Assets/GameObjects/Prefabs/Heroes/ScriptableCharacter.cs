using System;
using Assets.Controllers;
using Assets.GameObjects.Heroes;
using Assets.GameObjects.Weapons;
using Assets.ScriptableObjects;
using Assets.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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

        [SerializeField]
        private Text SpeedText;

        [SerializeField]
        private Text StrengthText;

        [SerializeField]
        private Text JumpText;

        public GameObject[] HeroButtons;

        private Button currentHeroBtn;
        private InputController inputController;
        private FinalMenuController finalMenuController;
        private Hero currentHero;
        private bool gameover = false;
        private int currentHeroIndex;
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
                JumpText.text = Math.Round(_jumping, 0).ToString();
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
                SpeedText.text = Math.Round(_speed, 0).ToString();
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
                StrengthText.text = Math.Round(_strength, 0).ToString();
                Health.Strength = _strength;
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

            set
            {
                health = value;
            }
        }


        void Start()
        {
            currentHeroIndex = PlayerPrefs.GetInt("SelectedHero");
            InitHero(currentHeroIndex);
            inputController = GameManager.GetComponent<InputController>();
            inputController.SwitchHero += OnHeroSwitch;
            inputController.MoveRight += MoveRight;
            inputController.RestartGame += RestartGame;
            inputController.MoveLeft += MoveLeft;
            inputController.Jump += Jump;
            //inputController.Attack += Attack;
            rb = GetComponent<Rigidbody2D>();
            col = GetComponent<SphereCollider>();
        }

        void InitHero(int index)
        {
            currentHeroBtn = HeroButtons[currentHeroIndex].GetComponent<Button>();
            currentHeroBtn.image.color = Color.green;
            currentHero = Heroes[index];
            Jumping = currentHero.Jumping;
            Speed = currentHero.Speed;
            Strength = currentHero.Strength;
            Health.InitializeHealth(currentHero.CurrentLife, currentHero.Life);
            Health.Strength = currentHero.Strength;
            shootAttack.InitializeWithAmmo(currentHero.Ammo);

        }


        public void OnHeroSwitch()
        {
            if (currentHero.isDead)
            {
                currentHeroBtn = HeroButtons[currentHeroIndex].GetComponent<Button>();
                currentHeroBtn.image.color = Color.red;
            }
            else
            {
                currentHeroBtn = HeroButtons[currentHeroIndex].GetComponent<Button>();
                currentHeroBtn.image.color = Color.white;
            }
            // Save Current Lifepoints
            currentHero.CurrentLife = Health.currentHealth;

            var startIndex = currentHeroIndex;
            currentHeroIndex++;
            if (currentHeroIndex > 2)
            {
                currentHeroIndex = 0;
            }

            while (Heroes[currentHeroIndex].isDead)
            {
                if (startIndex == currentHeroIndex && currentHero.isDead)
                {
                    Finish("all Heroes are dead");
                    break;
                }
                currentHeroIndex++;
                if (currentHeroIndex > 2)
                {
                    currentHeroIndex = 0;
                }
            }
            PlayerPrefs.SetInt("SelectedHero", currentHeroIndex);
            print(Heroes[currentHeroIndex].Name);
            InitHero(currentHeroIndex);
        }

        private void Finish(string reason)
        {
            gameover = true;
            finalMenuController = GameManager.GetComponent<FinalMenuController>();
            Transform child = finalMenuController.FinalMenu.transform.Find("FinalText");
            TextMeshProUGUI text = child.GetComponent<TextMeshProUGUI>();
            text.SetText("you lost because " + reason);
            finalMenuController.FinalMenu.SetActive(true);
        }

        void RestartGame()
        {
            if (gameover == true)
            {
                var setup = GameManager.GetComponent<GameSetup>();
                setup.ResetHeroes();
                SceneManager.LoadScene(1);
            }
        }

        void FixedUpdate()
        {
            if (!gameover)
            {
                if (health.isDead || transform.position.y < -50) //dies because falling of the ground 
                {
                    currentHero.isDead = true;
                    OnHeroSwitch();
                }
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
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }

        public int GetNumberOfAliveHeroes()
        {
            int counter = 0;
            for (int i = 0; i < Heroes.Length; i++)
            {
                if (!Heroes[i].isDead)
                {
                    counter++;
                }
            }
            return counter;
        }

    }
}
