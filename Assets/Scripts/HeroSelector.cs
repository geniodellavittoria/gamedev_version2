using Assets.Controllers;
using Assets.GameObjects.Characters;
using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Assets.ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class HeroSelector : MonoBehaviour {

        [SerializeField]
        private Hero[] heroes;
        public GameObject heroSelectPanel;
        
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