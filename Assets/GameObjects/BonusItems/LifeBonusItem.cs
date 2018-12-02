using System;
namespace Assets.GameObjects.BonusItems
{
    public class LifeBonusItem : BonusItem
    {
        private new void Start()
        {
            base.Start();
            Type = BonusItemType.Life;
        }
    }
}
