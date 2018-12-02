using System;
using Assets.GameObjects.Characters;
using UnityEngine;

namespace Assets.GameObjects.BonusItems
{
    public class SpeedBonusItem : BonusItem
    {
        private new void Start()
        {
            Type = BonusItemType.Speed;
            bonusValues = new int[] { 1, 2, 3 };
            base.Start();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("hero"))
            {
                Hero.GetComponent<ScriptableCharacter>().Speed += Value;
                base.OnTriggerEnter2D(col);
            }
        }
    }
}
