using System;
using Assets.GameObjects.Characters;
using Assets.GameObjects.Heroes;
using UnityEngine;

namespace Assets.GameObjects.BonusItems
{
    public class ImmutabilityBonusItem : DurationBonusItem
    {
        public new string BonusText
        {
            get
            {
                return BonusItemType.Immutability + " activated";
            }
        }

        private new void Start()
        {
            Type = BonusItemType.Immutability;
            DurationValues = new float[] { 2.0f, 3.0f, 4.0f };
            base.Start();
        }

        public override void Activate()
        {
            Hero.GetComponent<HeroHealth>().Immutable = true;
        }

        public override void Deactivate()
        {
            Hero.GetComponent<HeroHealth>().Immutable = false;
        }

    }
}
