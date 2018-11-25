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
        private int[] bonusValues = new int[] { 5, 10, 15, 20, 25 };

        public void Start()
        {
        }

        public void Consume(Collider2D col, ScriptableCharacter hero)
        {
            if (col.gameObject.CompareTag("bonus"))
            {
                var bonus = GetBonusValue();
                hero.Life += bonus;
                var text = "+" + bonus.ToString() + " Life";
                col.gameObject.SetActive(false);
                StartCoroutine(ShowText(text));
            }
        }

        IEnumerator ShowText(string text)
        {
            BonusText.text = text;
            yield return new WaitForSeconds(3);
            BonusText.text = " ";
        }

        private int GetBonusValue()
        {
            var ran = UnityEngine.Random.Range(0, bonusValues.Length);
            return bonusValues[ran];
        }


    }
}
