﻿using System;
using Assets.GameObjects.Characters;
using UnityEngine;

namespace Assets.GameObjects.BonusItems
{
    public class SpeedBonusItem : DurationBonusItem
    {
        private new void Start()
        {
            Type = BonusItemType.Speed;
            DurationValues = new float[] { 2.0f, 3.0f, 4.0f };
            BonusValues = new int[] { 1, 2, 3 };
            base.Start();
        }

        public override void Activate()
        {
            Hero.GetComponent<ScriptableCharacter>().Speed += Value;
        }

        public override void Deactivate()
        {
            Hero.GetComponent<ScriptableCharacter>().Speed -= Value;
        }
    }
}
