using System;

namespace Assets.GameObjects.BonusItems
{
    public interface IDurationBonusItem : IBonusItem
    {
        float Duration { get; set; }
        float[] DurationValues { get; set; }
        float Timer { get; set; }

        bool Finished { get; set; }

        void Deactivate();
    }
}
