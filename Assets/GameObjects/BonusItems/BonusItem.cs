using UnityEngine;
using System.Collections;
using Assets.Controllers;
using UnityEngine.UI;

namespace Assets.GameObjects.BonusItems
{
    public class BonusItem : MonoBehaviour, IBonusItem
    {
        [SerializeField]
        private GameObject gameManager;

        [SerializeField]
        private GameObject hero;

        private BonusItemController bonusItemController;
        private BonusItemType bonusItemType;
        private int _value;

        public bool triggered;

        private int[] bonusValues;
        private string bonusText;

        public GameObject GameManager
        {
            get
            {
                return gameManager;
            }
        }

        public BonusItemController BonusItemController
        {
            get
            {
                return bonusItemController;
            }

            set
            {
                bonusItemController = value;
            }
        }

        public BonusItemType Type
        {
            get
            {
                return bonusItemType;
            }
            set
            {
                bonusItemType = value;
            }
        }
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public string BonusText
        {
            get
            {
                var text = "";
                if (Value >= 0)
                {
                    text += "+";
                }
                return text + Value + " " + bonusItemType.ToString();
            }

            set
            {
                bonusText = value;
            }
        }

        public int[] BonusValues
        {
            get
            {
                return bonusValues;
            }
            set
            {
                bonusValues = value;
            }

        }


        public GameObject Hero
        {
            get
            {
                return hero;
            }
            set
            {
                hero = value;
            }
        }

        public bool Triggered
        {
            get
            {
                return triggered;
            }
        }

        protected void Start()
        {
            BonusItemController = gameManager.GetComponent<BonusItemController>();
            Value = GetBonusValue();
        }

        protected void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("hero") && !Triggered)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<Collider2D>().enabled = false;
                BonusItemController.DisplayText(BonusText);
                triggered = true;
                Activate();
            }
        }

        protected int GetBonusValue()
        {
            if (BonusValues != null)
            {
                var ran = Random.Range(0, bonusValues.Length);
                return bonusValues[ran];
            }
            return 0;
        }

        public virtual void Activate()
        {

        }
    }
}
