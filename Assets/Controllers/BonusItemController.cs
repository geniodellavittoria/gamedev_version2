using Assets.GameObjects.Characters;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Controllers
{
    public class BonusItemController : MonoBehaviour
    {
        [SerializeField]
        public Text BonusText;


        public void Start()
        {
        }

        /*public void Consume(Collider2D col, ScriptableCharacter hero)
        {
            if (col.gameObject.CompareTag("bonus"))
            {
                hero.Health.AddHealth(bonus);
                var text = "+" + bonus.ToString() + " Life";
                col.gameObject.SetActive(false);

            }
        }*/

        public void DisplayText(string text)
        {
            StartCoroutine(ShowText(text));
        }

        public IEnumerator ShowText(string text)
        {
            BonusText.text = text;
            yield return new WaitForSeconds(3);
            BonusText.text = " ";
        }

    }
}
