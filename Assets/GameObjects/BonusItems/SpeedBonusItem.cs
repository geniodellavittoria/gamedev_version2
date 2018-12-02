using System;
namespace Assets.GameObjects.BonusItems
{
    public class SpeedBonusItem : BonusItem
    {
        private new void Start()
        {
            base.Start();
            Type = BonusItemType.Speed;
        }
    }
}
