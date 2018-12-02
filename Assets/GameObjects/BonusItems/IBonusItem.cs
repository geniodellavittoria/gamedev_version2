using System;
namespace Application
{
    public interface IBonusItem
    {
        BonusItemType Type { get; set; }
        int Value { get; set; }
    }
}
