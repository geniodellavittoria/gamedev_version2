using Assets.Controllers;
using Assets.GameObjects.Characters;
using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Assets.ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

namespace Assets.Scripts
{
    public class HeroSelector : MonoBehaviour {

        [SerializeField]
        private Hero[] heroes;
        public GameObject heroSelectPanel;

        private void Start()
        {
            if (!AllHeroesAreDead())
            {
                for (int i = 0; i < heroes.Length; i++)
                {
                    if (heroes[i].isDead)
                    {
                        var deadHero = heroSelectPanel.transform.GetChild(i);
                        deadHero.GetComponent<Button>().interactable = false;
                        deadHero.GetComponent<Image>().color = Color.red;
                    }
                }
            }
            else
            {
                heroSelectPanel.SetActive(false);
            }
        }

        private bool AllHeroesAreDead()
        {
            for (int i = 0; i< heroes.Length; i++)
            {
                if (!heroes[i].isDead)
                {
                    return false;
                }
            }
            return true;
        }

        public void OnHeroSelect(int heroChoice)
        {
            heroSelectPanel.SetActive(false);
            PlayerPrefs.SetInt("SelectedHero", heroChoice);
            LoadByIndex(1); //Load GameScene
        }

        public void LoadByIndex(int index)
        {
            SceneManager.LoadScene(index);
        }
    }
}