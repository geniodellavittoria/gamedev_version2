using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Controllers
{
    public class GameSetup: MonoBehaviour
    {
        public GameObject HeroMenu;

        public void ResetHeroes()
        {
            HeroSelector selector = (HeroSelector)HeroMenu.transform.GetComponentInChildren(typeof(HeroSelector));
            for (int i = 0; i < selector.heroes.Length; i++)
            {
                selector.heroes[i].isDead = false;
                selector.heroes[i].CurrentLife = selector.heroes[i].Life;
            }

        }

    }
}
