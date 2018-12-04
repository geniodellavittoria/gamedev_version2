using UnityEngine;
using System.Collections;

namespace Assets.GameObjects.Grounds
{
    public class Ground : MonoBehaviour, IGround
    {
        [SerializeField]
        private GameObject hero;
        private int _value;
        private GroundNature _nature;

        private bool heroOnGround = false;


        public GroundNature Nature
        {
            get
            {
                return _nature;
            }

            set
            {
                _nature = value;
            }
        }

        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public bool HeroOnGround
        {
            get
            {
                return heroOnGround;
            }
        }

        public GameObject Hero
        {
            get
            {
                return hero;
            }
        }

        protected void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("hero"))
            {
                heroOnGround = true;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("hero"))
            {
                heroOnGround = false;
            }
        }
    }
}
