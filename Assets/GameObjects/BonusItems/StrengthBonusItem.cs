using UnityEngine;
using System.Collections;
using Assets.GameObjects.Characters;

namespace Assets.GameObjects.BonusItems
{
    public class StrengthBonusItem : DurationBonusItem
    {

        private new void Start()
        {
            Type = BonusItemType.Strength;
            DurationValues = new float[] { 2.0f, 3.0f, 4.0f };
            BonusValues = new int[] { -2, -1, 1, 2, 3 };
            base.Start();
        }

        public override void Activate()
        {
            Hero.GetComponent<ScriptableCharacter>().Strength += Value;
        }

        public override void Deactivate()
        {
            Hero.GetComponent<ScriptableCharacter>().Strength -= Value;
        }
    }
}
