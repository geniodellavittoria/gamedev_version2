using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Controllers
{
    public class GameSetup : MonoBehaviour
    {
        public GameObject HeroMenu;
        public Text playerName;

        public void ResetHeroes()
        {
            HeroSelector selector = (HeroSelector)HeroMenu.transform.GetComponentInChildren(typeof(HeroSelector));
            for (int i = 0; i < selector.heroes.Length; i++)
            {
                selector.heroes[i].isDead = false;
                selector.heroes[i].CurrentLife = selector.heroes[i].Life;
            }

        }

        private int GetHighScore()
        {
            return PlayerPrefs.GetInt("HighScoreValue");
        }

        public void OnSaveButtonClick()
        {
            var highscore = GetHighScore();
            var score = PlayerPrefs.GetInt("ScoreValue");
            if (highscore < score)
            {
                PlayerPrefs.SetInt("HighScoreValue", score);
                PlayerPrefs.SetString("HighScoreName", playerName.text);
                PlayerPrefs.SetString("HighScoreDate", DateTime.Now.ToString());
            }
            SceneManager.LoadScene(0);
        }
    }
}
