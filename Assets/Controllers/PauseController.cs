﻿using UnityEngine;
using System.Collections;
using System;

namespace Assets.Controllers
{
    public class PauseController : MonoBehaviour
    {
        [SerializeField]
        private InputController InputController;

        [SerializeField]
        private GameObject PauseMenu;

        private bool IsPaused = false;

        // Use this for initialization
        void Start()
        {
            Time.timeScale = 1;
            InputController.Pause += TogglePauseMenu;
        }

        private void TogglePauseMenu()
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                PauseMenu.SetActive(true);
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                PauseMenu.SetActive(false);
            }
        }


    }
}