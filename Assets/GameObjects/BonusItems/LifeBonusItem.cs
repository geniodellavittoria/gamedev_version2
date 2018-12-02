using System;
using Assets.GameObjects.Heroes;
using UnityEngine;

namespace Assets.GameObjects.BonusItems
{
    public class LifeBonusItem : BonusItem
    {
        private new void Start()
        {
            Type = BonusItemType.Life;
            bonusValues = new int[] { 5, 10, 15, 20, 25 };
            base.Start();
        }

        private new void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("hero"))
            {
                Hero.GetComponent<HeroHealth>().AddHealth(Value);
                base.OnTriggerEnter2D(col);
            }
        }
    }
}
