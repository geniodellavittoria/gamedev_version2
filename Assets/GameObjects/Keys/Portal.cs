using Assets.Controllers;
using Assets.GameObjects.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.GameObjects.Keys
{
    public class Portal : MonoBehaviour
    {

        [SerializeField]
        private GameObject WinMenu;
        [SerializeField]
        private Text ScoreText;
        [SerializeField]
        private Text HeroValue;
        [SerializeField]
        private Text TimeValue;
        [SerializeField]
        private GameObject GameManager;
        [SerializeField]
        private TimeController timeController;
        private KeyController KeyController;
        public ScriptableCharacter character;

        private void Start()
        {
            KeyController = GameManager.GetComponent<KeyController>();
            if (KeyController == null)
            {
                print("Defined GameManager does not contain any KeyController");
            }
        }

        private void Update()
        {
            if (KeyController.AllKeysFound())
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                gameObject.GetComponent<Collider2D>().enabled = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("hero"))
            {
                print("You won");
                string time = timeController.GetTimerText();
                int timePoints = (int)timeController.GetTimer() + 1;
                TimeValue.text = time + " = " + timePoints.ToString() + " Points";

                int heroPoints = character.GetNumberOfAliveHeroes();
                HeroValue.text = heroPoints.ToString();

                int totalPoints = timePoints + heroPoints;
                ScoreText.text = totalPoints.ToString();
                PlayerPrefs.SetInt("ScoreValue", totalPoints);
                WinMenu.SetActive(true);
            }
        }
    }
}
