using UnityEngine;
using System.Collections;

namespace Assets.GameObjects.BonusItems
{
    public class ToughnessBonusItem : BonusItem
    {

        private new void Start()
        {
            base.Start();
            Type = BonusItemType.Toughness;
        }
    }
}
