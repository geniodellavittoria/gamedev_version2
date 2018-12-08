using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

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

        public void TogglePauseMenu()
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

        public void EndGame()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0); //MainScene
        }




    }
}
