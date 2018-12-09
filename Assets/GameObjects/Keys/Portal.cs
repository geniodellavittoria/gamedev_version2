using Assets.Controllers;
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
        private GameObject GameManager;
        [SerializeField]
        private TimeController timeController;
        private KeyController KeyController;

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
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                gameObject.GetComponent<Collider2D>().enabled = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("hero"))
            {
                print("You won");
                int time = (int)timeController.GetTimer();
                PlayerPrefs.SetInt("ScoreValue", time);
                ScoreText.text = time.ToString();
                WinMenu.SetActive(true);
            }
        }
    }
}
