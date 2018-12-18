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
        public event Action RestartGame = delegate { };

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
            if (Input.GetKeyDown(InputControlsManager.ControlManager.jump))
            {
                Jump();
            }
            if (Input.GetKey(InputControlsManager.ControlManager.left1) || Input.GetKey(InputControlsManager.ControlManager.left2))
            {
                MoveLeft();
            }
            if (Input.GetKey(InputControlsManager.ControlManager.right1) || Input.GetKey(InputControlsManager.ControlManager.right2))
            {
                MoveRight();
            }
            if (Input.GetKeyDown(InputControlsManager.ControlManager.pause))
            {
                Pause();
            }
            if (Input.GetKeyDown(InputControlsManager.ControlManager.attack))
            {
                Attack();
            }
            if (Input.GetKeyDown(InputControlsManager.ControlManager.shoot))
            {
                Shoot();
            }
            if (Input.GetKeyDown(InputControlsManager.ControlManager.switchHero))
            {
                SwitchHero();
            }
            if (Input.GetKeyDown(InputControlsManager.ControlManager.restartGame))
            {
                RestartGame();
            }

        }

    }
}
