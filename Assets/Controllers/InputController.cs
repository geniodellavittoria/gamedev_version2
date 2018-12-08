using Assets.GameObjects.Characters;
using System;
using UnityEngine;

namespace Assets.Controllers
{
    public class InputController : MonoBehaviour
    {
        public event Action Jump = delegate { };
        public event Action MoveRight = delegate { };
        public event Action MoveLeft = delegate { };
        public event Action Shoot = delegate { };
        public event Action Pause = delegate { };
        public event Action Attack = delegate { };
        public event Action SwitchHero = delegate { };

        protected static InputController s_Instance;

        public static InputController Instance
        {
            get
            {
                return s_Instance;
            }
        }

        void Start()
        {
        }
        void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                MoveLeft();
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                MoveRight();
            }
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                Pause();
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                Attack();
            }
            if (Input.GetKeyDown(KeyCode.S)){
                Shoot();
            }
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                SwitchHero();
            }

        }

    }
}
