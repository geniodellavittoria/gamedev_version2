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
            BonusValues = new int[] { 5, 10, 15, 20, 25 };
            base.Start();
        }

        public override void Activate()
        {
            Hero.GetComponent<HeroHealth>().AddHealth(Value);
        }

    }
}
