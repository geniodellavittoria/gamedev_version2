using Assets.GameObjects.Character;
using System;
using UnityEngine;

namespace Assets.Controllers
{
    public class InputController :MonoBehaviour
    {
        public event Action Jump = delegate { };
        public event Action Move = delegate { };
        public event Action Shoot = delegate { };

        protected static InputController s_Instance;
        [SerializeField]
        private GameObject hero;

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
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
            if (Input.GetKey(KeyCode.A))
            {
                Move();   
            }
            if (Input.GetKey(KeyCode.D))
            {
                Move();
            }
        }

    }
}
