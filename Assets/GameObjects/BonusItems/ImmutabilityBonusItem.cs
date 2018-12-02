using System;
namespace Assets.GameObjects.BonusItems
{
    public class ImmutabilityBonusItem : BonusItem
    {
        private new void Start()
        {
            base.Start();
            Type = BonusItemType.Immutability;
        }
    }
}
