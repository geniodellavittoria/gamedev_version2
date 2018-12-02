using UnityEngine;
using System.Collections;

namespace Assets.GameObjects.BonusItems
{
    public class ToughnessBonusItem : BonusItem
    {

        private new void Start()
        {
            Type = BonusItemType.Toughness;
            bonusValues = new int[] { 1, 2, 3 };
            base.Start();
        }
    }
}
