using UnityEngine;
using System.Collections;
using Assets.GameObjects.Heroes;

namespace Assets.GameObjects.BonusItems
{
    public class AmmoBonusItem : BonusItem
    {

        private new void Start()
        {
            Type = BonusItemType.Ammo;
            BonusValues = new int[] { 5, 10, 15, 20 };
            base.Start();
        }

        public override void Activate()
        {
            Hero.GetComponent<HeroShootAttack>().AddAmmo(Value);
        }

    }
}
