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
        public Hero[] heroes;
        public GameObject heroSelectPanel;
        public GameObject FinalMenu;
        public GameObject HeroMenu;
        private SceneController sceneController;

       
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