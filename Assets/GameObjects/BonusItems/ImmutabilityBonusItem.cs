using System;
namespace Assets.GameObjects.BonusItems
{
    public class ImmutabilityBonusItem : BonusItem
    {
        private new void Start()
        {
            Type = BonusItemType.Immutability;
            bonusValues = new int[] { 1, 2, 3 };
            base.Start();
        }
    }
}
