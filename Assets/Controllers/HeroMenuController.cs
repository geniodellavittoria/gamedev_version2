using UnityEngine;
using System.Collections;
using System;

namespace Assets.Controllers
{
    public class HeroMenuController : MonoBehaviour
    {
        [SerializeField]
        private GameObject HeroMenu;
        [SerializeField]
        private GameObject lifeText;
        [SerializeField]
        private GameObject bonusText;

        protected static HeroMenuController s_Instance;
        public static HeroMenuController Instance
        {
            get
            {
                return s_Instance;
            }
        }

        public void ShowMenu()
        {
            Time.timeScale = 0;
            lifeText.SetActive(false);
            bonusText.SetActive(false);
            HeroMenu.SetActive(true);
        }

    }
}
