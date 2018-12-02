using System;
namespace Assets.GameObjects.BonusItems
{
    public class TimeBonusItem : BonusItem
    {
        private new void Start()
        {
            Type = BonusItemType.Time;
            bonusValues = new int[] { 2, 4, 6, 8, 10 };
            base.Start();
        }
    }
}
