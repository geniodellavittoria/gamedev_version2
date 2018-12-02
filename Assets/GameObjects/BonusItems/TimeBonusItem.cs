using System;
namespace Assets.GameObjects.BonusItems
{
    public class TimeBonusItem : BonusItem
    {
        private new void Start()
        {
            base.Start();
            Type = BonusItemType.Time;
        }
    }
}
