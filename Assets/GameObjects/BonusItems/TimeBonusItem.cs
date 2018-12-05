using System;
using Assets.Controllers;
using UnityEngine;

namespace Assets.GameObjects.BonusItems
{
    public class TimeBonusItem : BonusItem
    {

        private new void Start()
        {
            Type = BonusItemType.Time;
            BonusValues = new int[] { 2, 4, 6, 8, 10 };
            base.Start();
        }

        public override void Activate()
        {
            GameManager.GetComponent<TimeController>().ReduceSeconds(Value);
        }
    }
}
