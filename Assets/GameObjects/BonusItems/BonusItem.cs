using UnityEngine;
using System.Collections;
using Assets.Controllers;
using UnityEngine.UI;

namespace Assets.GameObjects.BonusItems
{
    public class BonusItem : MonoBehaviour, IBonusItem
    {
        [SerializeField]
        private GameObject GameManager;

        private BonusItemController _bonusItemController;
        private BonusItemType _bonusItemType;
        private int _value;

        private int[] bonusValues = new int[] { 5, 10, 15, 20, 25 };
        private string _bonusText;

        public BonusItemController BonusItemController
        {
            get
            {
                return _bonusItemController;
            }

            set
            {
                _bonusItemController = value;
            }
        }

        public BonusItemType Type
        {
            get
            {
                return _bonusItemType;
            }
            set
            {
                _bonusItemType = value;
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
                return "+" + Value + " " + _bonusItemType.ToString();
            }

            set
            {
                _bonusText = value;
            }
        }

        // Use this for initialization
        protected void Start()
        {
            BonusItemController = GameManager.GetComponent<BonusItemController>();
            Value = GetBonusValue();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("hero"))
            {
                gameObject.SetActive(false);
                BonusItemController.DisplayText(BonusText);
            }
        }

        private int GetBonusValue()
        {
            var ran = Random.Range(0, bonusValues.Length);
            return bonusValues[ran];
        }
    }
}
