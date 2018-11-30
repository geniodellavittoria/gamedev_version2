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
            if (Input.GetKey(KeyCode.A))
            {
                MoveLeft();
            }
            if (Input.GetKey(KeyCode.D))
            {
                MoveRight();
            }
            if (Input.GetKey(KeyCode.Escape))
            {
                Pause();
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                Attack();
            }
            if (Input.GetKeyDown(KeyCode.J)){
                Shoot();
            }

        }

    }
}
