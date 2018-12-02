using System;
using Assets.Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.GameObjects.BonusItems
{
    public interface IBonusItem
    {
        BonusItemController BonusItemController { get; set; }
        BonusItemType Type { get; set; }
        int Value { get; set; }
        string BonusText { get; set; }
    }
}
